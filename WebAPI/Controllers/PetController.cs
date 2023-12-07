using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        IPetService _petService;
        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet("getall")]
        //[Authorize()]
        public IActionResult GetAll()
        {
            var result = _petService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbypetid")]
        public IActionResult GetByPetId(int petId)
        {
            var result = _petService.GetByPetId(petId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbypetownerid")]
        public IActionResult GetByOwnerId(int ownerId)
        {
            var result = _petService.GetByOwnerId(ownerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Pet petService)
        {
            var result = _petService.Add(petService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Pet petService)
        {
            var result = _petService.Delete(petService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Pet petService)
        {
            var result = _petService.Update(petService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
