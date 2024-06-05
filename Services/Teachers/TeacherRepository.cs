using Microsoft.EntityFrameworkCore;
using FiltroApi.Data;
using FiltroApi.Models;

namespace FiltroApi.Services
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly FiltroApiContext _context;

        public TeacherRepository(FiltroApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.ToList();
        }

        public Teacher GetOne(int id)
        {
            return _context.Teachers.Find(id);
        }

        public void Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public void Update(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }
    }
}