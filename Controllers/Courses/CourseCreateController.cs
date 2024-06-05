using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.AddControllers
{
    [ApiController]
    [Route("api/Courses")]
    
    public class CourseCreateController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseCreateController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPost]
        public IActionResult CreateCourse(Course course)
        {
            if (course == null)
            {
                return BadRequest("Datos nulos o erróneos");
            }
            try
            {
                _courseRepository.Create(course);
                return Ok(course);
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el curso: {ex.Message}");
            }
        }
    }
}