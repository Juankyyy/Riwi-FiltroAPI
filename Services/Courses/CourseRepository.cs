using Microsoft.EntityFrameworkCore;
using FiltroApi.Data;
using FiltroApi.Models;

namespace FiltroApi.Services
{
    public class CourseRepository : ICourseRepository
    {
        private readonly FiltroApiContext _context;

        public CourseRepository(FiltroApiContext context)
        {
            _context = context;
        }

        // Listar todos los cursos incluyendo Teacher
        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.Include(c => c.Teacher).ToList();
        }

        // Listar curso con id incluyendo Teacher
        public Course GetOne(int id)
        {
            return _context.Courses.Include(c => c.Teacher).FirstOrDefault(c => c.Id == id);
        }

        // Crear nuevo curso y guardar en la db
        public void Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        // Editar un curso y guardar en la db
        public void Update(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }
    }
}