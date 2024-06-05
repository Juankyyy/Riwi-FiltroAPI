using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.AddControllers
{
    [ApiController]
    [Route("api/Courses")]
    
    public class CourseUpdateController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseUpdateController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(Course course)
        {
            if (course == null)
            {
                return BadRequest("Datos nulos o erróneos");
            }
            try
            {
                _courseRepository.Update(course);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el curso {course.Name}: {ex.Message}");
            }
        }
    }
}