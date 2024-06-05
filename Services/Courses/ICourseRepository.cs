using FiltroApi.Models;

namespace FiltroApi.Services
{
    public interface ICourseRepository
    {
        public IEnumerable<Course> GetAll();
        public Course GetOne(int id);
        public void Create(Course course);
        public void Update(Course course);
    }
}