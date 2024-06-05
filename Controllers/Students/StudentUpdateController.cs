using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.AddControllers
{
    [ApiController]
    [Route("api/Students")]
    
    public class StudentUpdateController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentUpdateController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(Student student)
        {
            if (student == null)
            {
                return BadRequest("Datos nulos o erróneos");
            }
            try
            {
                _studentRepository.Update(student);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el estudiante {student.Names}: {ex.Message}");
            }
        }
    }
}