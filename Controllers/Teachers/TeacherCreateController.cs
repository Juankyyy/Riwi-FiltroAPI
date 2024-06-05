using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.AddControllers
{
    [ApiController]
    [Route("api/Teachers")]
    
    public class TeacherCreateController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherCreateController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpPost]
        public IActionResult CreateTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                return BadRequest("Datos nulos o erróneos");
            }
            try
            {
                _teacherRepository.Create(teacher);
                return Ok(teacher);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el profesor: {ex.Message}");
            }
        }
    }
}
