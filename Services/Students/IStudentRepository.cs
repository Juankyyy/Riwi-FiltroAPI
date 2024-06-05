using FiltroApi.Models;

namespace FiltroApi.Services
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAll();
        public Student GetOne(int id);
        public void Create(Student student);
        public void Update(Student student);
    }
}