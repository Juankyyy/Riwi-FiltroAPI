using Microsoft.EntityFrameworkCore;
using FiltroApi.Data;
using FiltroApi.Models;

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
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }

        public void Update(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
        }
    }
}