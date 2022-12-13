using System.ComponentModel.DataAnnotations;

namespace GameGuidanceAPI.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string? QuestionName { get; set; }

    }
}