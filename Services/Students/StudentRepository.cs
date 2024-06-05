using Microsoft.EntityFrameworkCore;
using FiltroApi.Data;
using FiltroApi.Models;

namespace FiltroApi.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly FiltroApiContext _context;

        public StudentRepository(FiltroApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetOne(int id)
        {
            return _context.Students.Find(id);
        }

        public void Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}