using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.AddControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            try
            {
                return Ok(_courseRepository.GetAll());

            } catch (Exception ex)
            {
                return BadRequest($"Error al traer los cursos: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            try
            {
                var course = _courseRepository.GetOne(id);

                if (course == null)
                {
                    return NotFound($"Estudiante con id {id} no encontrado");
                }

                return Ok(course);
            } catch (Exception ex)
            {
                return BadRequest($"Error al traer el curso con id {id}: {ex.Message}");
            }
        }
    }
}