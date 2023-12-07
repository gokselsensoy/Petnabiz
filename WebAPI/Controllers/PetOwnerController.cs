using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetOwnerController : ControllerBase
    {
        IPetOwnerService _petOwnerService;
        public PetOwnerController(IPetOwnerService petOwnerService)
        {
            _petOwnerService = petOwnerService;
        }


        [HttpGet("getall")]
        //[Authorize()]
        public IActionResult GetAll()
        {
            var result = _petOwnerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbypetownerid")]
        public IActionResult GetByOwnerId(int ownerId)
        {
            var result = _petOwnerService.GetByOwnerId(ownerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyclinicid")]
        public IActionResult GetByClinicId(int clinicId)
        {
            var result = _petOwnerService.GetByClinicId(clinicId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(PetOwner petOwnerService)
        {
            var result = _petOwnerService.Add(petOwnerService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PetOwner petOwnerService)
        {
            var result = _petOwnerService.Delete(petOwnerService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PetOwner petOwnerService)
        {
            var result = _petOwnerService.Update(petOwnerService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
