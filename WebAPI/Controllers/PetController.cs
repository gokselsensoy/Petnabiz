using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {
        IPetService _petService;
        UserManager<AppUser> _userManager;
        public PetController(IPetService petService, UserManager<AppUser> userManager)
        {
            _petService = petService;
            _userManager = userManager;
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

        [HttpGet("getbypetuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _petService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [Authorize(Roles = "Veteriner")]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody]Pet pet)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            pet.AppUserId = user.Id;

            var result = _petService.Add(pet);
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
