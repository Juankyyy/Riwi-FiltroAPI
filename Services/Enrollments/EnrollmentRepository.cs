using Microsoft.EntityFrameworkCore;
using FiltroApi.Data;
using FiltroApi.Models;
using FiltroApi.AddControllers;
using Microsoft.AspNetCore.Identity.Data;

namespace FiltroApi.Services
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly FiltroApiContext _context;

        public EnrollmentRepository(FiltroApiContext context)
        {
            _context = context;
        }

        // Listar todas las matrículas incluyendo Student
        public IEnumerable<Enrollment> GetAll()
        {
            return _context.Enrollments.Include(c => c.Student).Include(c => c.Course).ToList();
        }

        // Listar matrícula con id incluyendo Student
        public Enrollment GetOne(int id)
        {
            return _context.Enrollments.Include(c => c.Student).Include(c => c.Course).FirstOrDefault(c => c.Id == id);
        }

        // Crear nueva matrícula y guardar en la db
        public void Create(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();

            // Info de la matrícula
            var student = _context.Students.Find(enrollment.StudentId);
            var course = _context.Courses.Find(enrollment.CourseId);
            var teacher = _context.Teachers.Find(course.TeacherId);

            // Se crea una instancia de EmailController
            MailController Email = new MailController();
            Email.SendEmail(student.Email, student.Names, course.Name, course.Description, course.Schedule, course.Duration, course.Capacity, teacher.Names, enrollment.Status);
        }

        // Editar una matrícula y guardar en la db
        public void Update(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
        }

        // Listar matrículas en la fecha incluyendo el estudiante y el curso
        public IEnumerable<Enrollment> Date(DateOnly date)
        {
            var enrollments = _context.Enrollments.Include(c => c.Student).Include(c => c.Course).Where(c => c.Date == date);

            return enrollments;
        }
    }
}