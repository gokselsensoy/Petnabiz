using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("degisiklik")]
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

        [HttpGet("getbyuserid")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            //var value = await _userManager.FindByNameAsync(User.Identity.Name); 
            var result = _petService.GetByUserId(userId);
          

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(Pet pet)
        {
            var user = await _userManager.FindByIdAsync(Convert.ToString(pet.AppUserId));
            pet.AppUserId = user.Id;

            var result = _petService.Add(pet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Pet pet)
        {
            var result = _petService.Delete(pet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Pet pet)
        {
            var result = _petService.Update(pet);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
