using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FiltroApi.Models
{
    public class Course
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        [Required]
        public string? Schedule { get; set; }

        [Required]
        public string? Duration { get; set; }

        [Required]
        public int Capacity { get; set; }
    }
}