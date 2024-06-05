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

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.Include(c => c.Teacher).ToList();
        }

        public Course GetOne(int id)
        {
            return _context.Courses.Include(c => c.Teacher).FirstOrDefault(c => c.Id == id);
        }

        public void Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }
    }
}