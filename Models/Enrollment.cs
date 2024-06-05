using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FiltroApi.Models
{
    public class Enrollment
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateOnly? Date { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        [Required]
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        [Required]
        public string? Status { get; set; }
    }
}