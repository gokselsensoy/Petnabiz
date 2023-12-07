using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VetController : ControllerBase
    {
        IVetService _vetService;
        public VetController(IVetService vetService)
        {
            _vetService = vetService;
        }

        [HttpGet("getall")]
        //[Authorize()]
        public IActionResult GetAll()
        {
            var result = _vetService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyvetid")]
        public IActionResult GetByVetId(int vetId)
        {
            var result = _vetService.GetByVetId(vetId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyclinicid")]
        public IActionResult GetByClinicId(int clinicId)
        {
            var result = _vetService.GetByClinicId(clinicId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Vet vetService)
        {
            var result = _vetService.Add(vetService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Vet vetService)
        {
            var result = _vetService.Delete(vetService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Vet vetService)
        {
            var result = _vetService.Update(vetService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
