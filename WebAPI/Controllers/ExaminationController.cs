using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        IExaminationService _examinationService;
        public ExaminationController(IExaminationService examinationService)
        {
            _examinationService = examinationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _examinationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("examinationdetail")]
        public IActionResult GetExaminationDetail(int userId)
        {
            var result = _examinationService.GetExaminationDetails(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("petexaminationdetail")]
        public IActionResult GetPetExaminationDetail(int petId)
        {
            var result = _examinationService.GetPetExaminationDetails(petId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("pastexaminationdetail")]
        public IActionResult GetPastExaminationDetail(int clinicId)
        {
            var result = _examinationService.GetPastExaminationDetails(clinicId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyexaminationid")]
        public IActionResult GetByExaminationId(int examinationId)
        {
            var result = _examinationService.GetByExaminationId(examinationId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbypetid")]
        public IActionResult GetByPetId(int petId)
        {
            var result = _examinationService.GetByPetId(petId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _examinationService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyclinicid")]
        public IActionResult GetByClinicId(int clinicId)
        {
            var result = _examinationService.GetByClinicId(clinicId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyvetid")]
        public IActionResult GetByVetId(int vetId)
        {
            var result = _examinationService.GetByVetId(vetId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        //[Authorize(Roles = "Veteriner")]
        [HttpPost("add")]
        public IActionResult Add(Examination examination)
        {
            var result = _examinationService.Add(examination);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[Authorize(Roles = "Veteriner")]
        [HttpPost("delete")]
        public IActionResult Delete(Examination examination)
        {
            var result = _examinationService.Delete(examination);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[Authorize(Roles = "Veteriner")]
        [HttpPost("update")]
        public IActionResult Update(Examination examination)
        {
            var result = _examinationService.Update(examination);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
