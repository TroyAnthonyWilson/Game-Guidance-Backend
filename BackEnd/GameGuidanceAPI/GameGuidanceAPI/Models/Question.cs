using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameGuidanceAPI.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string? QuestionName { get; set; }

    }
}