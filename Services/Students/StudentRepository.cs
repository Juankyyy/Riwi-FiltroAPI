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

        // Listar todos los estudiantes
        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        // Listar estudiante con id
        public Student GetOne(int id)
        {
            return _context.Students.Find(id);
        }
        
        // Crear nuevo estudiante y guardar en la db
        public void Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        // Editar un estudiante y guardar en la db
        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        // Listar todas las matrículas que tiene un estudiante determinado
        public IEnumerable<Enrollment> EnrollmentsStudent(int id)
        {
            return _context.Enrollments.Include(c => c.Student).Include(c => c.Course).Where(c => c.StudentId == id);
        }

        // Listar todos los estudiantes que cumplen años en determinada fecha
        public IEnumerable<Student> StudentsBirthday(DateOnly date)
        {
            return _context.Students.Where(s => s.BirthDate == date);
        }
    }
}