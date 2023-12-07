using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

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
        //[Authorize()]
        public IActionResult GetAll()
        {
            var result = _examinationService.GetAll();
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

        [HttpGet("getbypetownerid")]
        public IActionResult GetByOwnerId(int ownerId)
        {
            var result = _examinationService.GetByOwnerId(ownerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbypetvetid")]
        public IActionResult GetByVetId(int vetId)
        {
            var result = _examinationService.GetByVetId(vetId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Examination examinationService)
        {
            var result = _examinationService.Add(examinationService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Examination examinationService)
        {
            var result = _examinationService.Delete(examinationService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Examination examinationService)
        {
            var result = _examinationService.Update(examinationService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
