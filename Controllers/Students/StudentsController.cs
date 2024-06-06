using Microsoft.AspNetCore.Mvc;
using FiltroApi.Models;
using FiltroApi.Services;

namespace FiltroApi.AddControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            try
            {
                return Ok(_studentRepository.GetAll());

            } catch (Exception ex)
            {
                return BadRequest($"Error al traer los estudiantes: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            try
            {
                var student = _studentRepository.GetOne(id);

                if (student == null)
                {
                    return NotFound($"Estudiante con id {id} no encontrado");
                }

                return Ok(student);
            } catch (Exception ex)
            {
                return BadRequest($"Error al traer el estudiante con id {id}: {ex.Message}");
            }
        }

        [HttpGet, Route("{id}/Enrollments")]
        public ActionResult<IEnumerable<Enrollment>> GetEnrollmentsStudent(int id)
        {
            var enrollments = _studentRepository.EnrollmentsStudent(id);
            
            if (enrollments == null)
            {
                return NotFound($"Matrículas del estudiante con id {id} no encontradas");
            }
            try
            {
                return Ok(enrollments);
            } catch (Exception ex)
            {
                return BadRequest($"Error al traer las matrículas del estudiante con id {id}: {ex.Message}");
            }
        }

        [HttpGet, Route("{date}/Birthday")]
        public ActionResult<IEnumerable<Student>> GetStudentsBirthday(DateOnly date)
        {
            var students = _studentRepository.StudentsBirthday(date);
            
            if (students == null)
            {
                return NotFound($"Estudiantes con fecha de cumpleaños {date} no encontrados");
            }
            try
            {
                return Ok(students);
            } catch (Exception ex)
            {
                return BadRequest($"Error al traer los estudiantes con fecha de cumpleaños {date}: {ex.Message}");
            }
        }
    }
}