using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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

        //[Authorize(Roles = "Veteriner")]
        [HttpPost("add")]
        public IActionResult Add(Vet vet)
        {
            var result = _vetService.Add(vet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[Authorize(Roles = "Veteriner")]
        [HttpPost("delete")]
        public IActionResult Delete(Vet vet)
        {
            var result = _vetService.Delete(vet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[Authorize(Roles = "Veteriner")]
        [HttpPost("update")]
        public IActionResult Update(Vet vet)
        {
            var result = _vetService.Update(vet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
