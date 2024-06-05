using Microsoft.EntityFrameworkCore;
using FiltroApi.Models;

namespace FiltroApi.Data
{
    public class FiltroApiContext : DbContext
    {
        public FiltroApiContext(DbContextOptions<FiltroApiContext> options) : base(options) {}

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}