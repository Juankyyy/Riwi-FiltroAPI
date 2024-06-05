using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.AddControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentsController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Enrollment>> GetEnrollments()
        {
            try
            {
                return Ok(_enrollmentRepository.GetAll());

            } catch (Exception ex)
            {
                return BadRequest($"Error al traer las matrículas: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEnrollment(int id)
        {
            try
            {
                var enrollment = _enrollmentRepository.GetOne(id);

                if (enrollment == null)
                {
                    return NotFound($"Matrícula con id {id} no encontrado");
                }

                return Ok(enrollment);
            } catch (Exception ex)
            {
                return BadRequest($"Error al traer la matrícula con id {id}: {ex.Message}");
            }
        }
    }
}