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
            var result = _veterinaryClinicService.GetByClinicId(user.Id);
            AppUserClinicDto appUserClinicDto = new AppUserClinicDto();
            appUserClinicDto.ClinicName = result.Data.ClinicName;
            if (result.Success)
            {
                return Ok(appUserClinicDto);
            }
            return BadRequest(result);
        }

        [HttpGet("clinicdetail")]
        public IActionResult GetClinicDetail(int clinicId)
        {
            var result = _veterinaryClinicService.GetClinicDetails(clinicId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
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

        [HttpGet("getbycityid")]
        public IActionResult GetByCityId(int cityId)
        {
            var result = _veterinaryClinicService.GetByCityId(cityId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbydistrictid")]
        public IActionResult GetByDistrictId(int districtId)
        {
            var result = _veterinaryClinicService.GetByDistrictId(districtId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        //[Authorize(Roles = "Yönetici")]
        [HttpPost("add")]
        public IActionResult Add(VeterinaryClinic veterinaryClinic)
        {
            var result = _veterinaryClinicService.Add(veterinaryClinic);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[Authorize(Roles = "Yönetici")]
        [HttpPost("delete")]
        public IActionResult Delete(VeterinaryClinic veterinaryClinic)
        {
            var result = _veterinaryClinicService.Delete(veterinaryClinic);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[Authorize(Roles = "Yönetici")]
        [HttpPost("update")]
        public IActionResult Update(VeterinaryClinic veterinaryClinic)
        {
            var result = _veterinaryClinicService.Update(veterinaryClinic);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
