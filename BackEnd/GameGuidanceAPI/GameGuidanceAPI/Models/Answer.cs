using System.ComponentModel.DataAnnotations;

namespace GameGuidanceAPI.Models
{
    public class Answer
    {
        [Key]
        public int? Id { get; set; }
        public int? Platform { get; set; }
        public int? GameMode { get; set; }
        public int? PlayerPerspective { get; set; }
        public int? Genre { get; set; }
        public int? Theme { get; set; }
        public double? Rating { get; set; }
    }
}