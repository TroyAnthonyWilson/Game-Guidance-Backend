using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameGuidanceAPI.Models
{
    public class Choice
    {
        [Key]
        public int Id { get; set; }
        public int ApiChoiceId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question? Question { get; set; }

        public string ChoiceName { get; set; }

    }
}