using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    ICityService _cityService;
    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    //deneme

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _cityService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int cityId)
    {
        var result = _cityService.GetById(cityId);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("add")]
    public IActionResult Add(City city)
    {
        var result = _cityService.Add(city);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("delete")]
    public IActionResult Delete(City city)
    {
        var result = _cityService.Delete(city);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
