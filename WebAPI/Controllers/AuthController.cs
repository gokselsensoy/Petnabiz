using Business.Abstract;
using Business.Concrete;
using Business.Utilities.JWT;
using System.IdentityModel.Tokens.Jwt;
using Core.Entities.Concrete;
using Core.Utilities.Extensions;
using Entities.Concrete;
using Entities.DTOs.AppUserDtos;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using WebAPI.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json.Linq;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using Business.Utilities.Results;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost("selectclinic")]
        public async Task<IActionResult> SelectClinic(AppUserChangeClinicDto appUserChangeClinicDto)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            user.ClinicId = appUserChangeClinicDto.ClinicId;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest();
        }




        [HttpPost("update")]
        public async Task<IActionResult> Update(AppUserEditDto appUserEditDto)
        {
            if(appUserEditDto.Password == appUserEditDto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);          

                user.PhoneNumber = appUserEditDto.PhoneNumber;
                user.Email = appUserEditDto.UserName;
                user.UserName = appUserEditDto.UserName;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(AppUserLoginDto appUserLoginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(appUserLoginDto.UserName, appUserLoginDto.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(appUserLoginDto.UserName);
                var token = _userService.CreateAccessToken(user);



                if (user.EmailConfirmed == true)
                {
                    return Ok(token);
                    //email adresinizi doğrulayınız
                }
            }
            //kullanıcı adı veya şifre hatalı
            return BadRequest(result);
        }

        [HttpGet("getuserinfo")]
        public async Task<ActionResult> GetUserInfos()
        {
            AppUserInfoDto appUserInfoDto = new AppUserInfoDto();
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var token = _userService.GetClaims(value);
            appUserInfoDto.Name = value.Name;
            appUserInfoDto.Surname = value.Surname;
            appUserInfoDto.UserName = value.UserName;
            return Ok(appUserInfoDto);
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                int code;
                code = random.Next(100000, 1000000);
                AppUser appUser = new AppUser()
                {
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    UserName = appUserRegisterDto.Email,
                    TCID = appUserRegisterDto.TCID,
                    ConfirmCode = code
                };

                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {

                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Petnabız Admin", "gkslsnsy@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz:" + code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Petnabız Onay Kodu";

                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("gkslsnsy@gmail.com", "kccvvprqygfckbrl");
                    client.Send(mimeMessage);
                    client.Disconnect(true);

                    TempData["Mail"] = appUserRegisterDto.Email;

                    return Ok(result);
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return BadRequest();
        }

        [HttpGet("registermail")]
        public IActionResult GetRegisterMail()
        {
            var value = TempData["Mail"];
            return Ok(value);
        }

        [HttpPost("confirmcode")]
        public async Task<IActionResult> Confirm(ConfirmMailModel confirmMailModel)
        {
            var user = await _userManager.FindByEmailAsync(confirmMailModel.Email);
            var result = _userService.CreateAccessToken(user);
            if (user.ConfirmCode == confirmMailModel.ConfirmCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return Ok(result);
            }
            return BadRequest(user);
        }
    }



    //fluent validation, identityvalidator
}
