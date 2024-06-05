using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.AddControllers
{
    [ApiController]
    [Route("api/Students")]
    
    public class StudentCreateController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentCreateController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (student == null)
            {
                return BadRequest("Datos nulos o erróneos");
            }
            try
            {
                _studentRepository.Create(student);
                return Ok(student);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear estudiante: {ex.Message}");
            }
        }
    }
}
