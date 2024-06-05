using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.AddControllers
{
    [ApiController]
    [Route("api/Teachers")]
    
    public class TeacherUpdateController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherUpdateController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                return BadRequest("Datos nulos o erróneos");
            }
            try
            {
                _teacherRepository.Update(teacher);
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el estudiante {teacher.Names}: {ex.Message}");
            }
        }
    }
}