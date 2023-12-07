using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinaryClinicController : ControllerBase
    {
        IVeterinaryClinicService _veterinaryClinicService;
        public VeterinaryClinicController(IVeterinaryClinicService veterinaryClinicService)
        {
            _veterinaryClinicService = veterinaryClinicService;
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
