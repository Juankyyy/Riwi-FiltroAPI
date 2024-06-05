using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.AddControllers
{
    [ApiController]
    [Route("api/Enrollments")]
    
    public class EnrollmentUpdateController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentUpdateController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEnrollment(Enrollment enrollment)
        {
            if (enrollment == null)
            {
                return BadRequest("Datos nulos o erróneos");
            }
            try
            {
                _enrollmentRepository.Update(enrollment);
                return Ok(enrollment);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar la matrícula: {ex.Message}");
            }
        }
    }
}