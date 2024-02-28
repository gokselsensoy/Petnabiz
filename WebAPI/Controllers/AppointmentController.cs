using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("isavailable")]
        public IActionResult IsAppointmentAvailable(int clinicId, DateTime selectedDate)
        {
            try
            {
                bool isAvailable = _appointmentService.IsAppointmentAvailable(clinicId, selectedDate);
                return Ok(new { IsAvailable = isAvailable });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("getavailable")]
        public IActionResult GetAvailableAppointments(int clinicId, DateTime selectedDate)
        {
            var result = _appointmentService.GetAvailableAppointments(clinicId, selectedDate);
            selectedDate.ToString("MM/dd/yyyy");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getappointmentdetails")]
        public IActionResult GetDetails(int clinicId)
        {
            var result = _appointmentService.GetAppointmentDetails(clinicId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _appointmentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _appointmentService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyclinicid")]
        public IActionResult GetByClinicId(int clinicId)
        {
            var result = _appointmentService.GetByClinicId(clinicId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbypetid")]
        public IActionResult GetByPetId(int petId)
        {
            var result = _appointmentService.GetByPetId(petId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int appointmentId)
        {
            var result = _appointmentService.GetById(appointmentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Appointment appointment)
        {
            var result = _appointmentService.Add(appointment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Appointment appointment)
        {
            var result = _appointmentService.Delete(appointment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
