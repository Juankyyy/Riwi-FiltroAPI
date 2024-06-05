using FiltroApi.Models;

namespace FiltroApi.Services
{
    public interface ITeacherRepository
    {
        public IEnumerable<Teacher> GetAll();
        public Teacher GetOne(int id);
        public void Create(Teacher teacher);
        public void Update(Teacher teacher);
    }
}