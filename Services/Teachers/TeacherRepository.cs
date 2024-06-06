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

        // Listar todos los profesores
        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.ToList();
        }

        // Listar profesor con id
        public Teacher GetOne(int id)
        {
            return _context.Teachers.Find(id);
        }

        // Crear nuevo profesor y guardar en la db
        public void Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        // Editar un profesor y guardar en la db
        public void Update(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }


        // Listar cursos del profesor con el id especificado
        public IEnumerable<Course> CoursesTeacher(int id)
        {
            return _context.Courses.Include(c => c.Teacher).Where(c => c.Id == id);
        }
    }
}