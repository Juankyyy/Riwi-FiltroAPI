using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.AddControllers
{
    [ApiController]
    [Route("api/Enrollments")]
    
    public class EnrollmentCreateController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentCreateController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpPost]
        public IActionResult CreateEnrollment(Enrollment enrollment)
        {
            if (enrollment == null)
            {
                return BadRequest("Datos nulos o erróneos");
            }
            try
            {
                _enrollmentRepository.Create(enrollment);
                return Ok(enrollment);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la matrícula: {ex.Message}");
            }
        }
    }
}