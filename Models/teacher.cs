using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FiltroApi.Models
{
    public class Teacher
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Names { get; set; }

        [Required]
        public string? Specialty { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public int YearsExperience { get; set; }

        [JsonIgnore]
        public List<Course>? Courses { get; set; }
    }
}