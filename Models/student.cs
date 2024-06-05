using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FiltroApi.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Names { get; set; }

        [Required]
        public DateOnly? BirthDate { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Email { get; set; }
    }
}