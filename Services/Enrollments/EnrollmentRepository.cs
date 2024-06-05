using Microsoft.EntityFrameworkCore;
using FiltroApi.Data;
using FiltroApi.Models;
using FiltroApi.AddControllers;

namespace FiltroApi.Services
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly FiltroApiContext _context;

        public EnrollmentRepository(FiltroApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Enrollment> GetAll()
        {
            return _context.Enrollments.Include(c => c.Student).Include(c => c.Course).ToList();
        }

        public Enrollment GetOne(int id)
        {
            return _context.Enrollments.Include(c => c.Student).Include(c => c.Course).FirstOrDefault(c => c.Id == id);
        }

        public void Create(Enrollment enrollment)
        {
            // _context.Enrollments.Add(enrollment);
            // _context.SaveChanges();

            var student = _context.Students.Find(enrollment.StudentId);
            var course = _context.Courses.Find(enrollment.CourseId);
            var teacher = _context.Teachers.Find(course.TeacherId);

            MailController Email = new MailController();
            Email.SendEmail(student.Email, student.Names, course.Name, course.Description, course.Schedule, course.Duration, course.Capacity, teacher.Names);
        }

        public void Update(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
        }
    }
}