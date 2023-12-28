using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Entities.DTOs.AppUserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinaryClinicController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        IVeterinaryClinicService _veterinaryClinicService;
        public VeterinaryClinicController(IVeterinaryClinicService veterinaryClinicService, UserManager<AppUser> userManager)
        {
            _veterinaryClinicService = veterinaryClinicService;
            _userManager = userManager;
        }

        [HttpGet("getuserclinic")]
        public async Task<IActionResult> GetUserClinic()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.UserName = user.Email;
            var result = _veterinaryClinicService.GetByClinicId(user.ClinicId);
            AppUserClinicDto appUserClinicDto = new AppUserClinicDto();
            appUserClinicDto.ClinicName = result.Data.ClinicName;
            if (result.Success)
            {
                return Ok(appUserClinicDto);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        //[Authorize()]
        public IActionResult GetAll()
        {
            var result = _veterinaryClinicService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyclinicid")]
        public IActionResult GetByClinicId(int clinicId)
        {
            var result = _veterinaryClinicService.GetByClinicId(clinicId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycity")]
        public IActionResult GetByCity(string city)
        {
            var result = _veterinaryClinicService.GetByCity(city);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [Authorize(Roles = "Yönetici")]
        [HttpPost("add")]
        public IActionResult Add(VeterinaryClinic veterinaryClinicService)
        {
            var result = _veterinaryClinicService.Add(veterinaryClinicService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Yönetici")]
        [HttpPost("delete")]
        public IActionResult Delete(VeterinaryClinic veterinaryClinicService)
        {
            var result = _veterinaryClinicService.Delete(veterinaryClinicService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "Yönetici")]
        [HttpPost("update")]
        public IActionResult Update(VeterinaryClinic veterinaryClinicService)
        {
            var result = _veterinaryClinicService.Update(veterinaryClinicService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
