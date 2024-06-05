using FiltroApi.Models;

namespace FiltroApi.Services
{
    public interface IEnrollmentRepository
    {
        public IEnumerable<Enrollment> GetAll();
        public Enrollment GetOne(int id);
        public void Create(Enrollment enrollment);
        public void Update(Enrollment enrollment);
    }
}