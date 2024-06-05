using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.AddControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeachersController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> GetTeachers()
        {
            try
            {
                return Ok(_teacherRepository.GetAll());

            } catch (Exception ex)
            {
                return BadRequest($"Error al traer los profesores: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTeacher(int id)
        {
            try
            {
                var teacher = _teacherRepository.GetOne(id);

                if (teacher == null)
                {
                    return NotFound($"Profesor con id {id} no encontrado");
                }

                return Ok(teacher);
            } catch (Exception ex)
            {
                return BadRequest($"Error al traer el profesor con id {id}: {ex.Message}");
            }
        }
    }
}