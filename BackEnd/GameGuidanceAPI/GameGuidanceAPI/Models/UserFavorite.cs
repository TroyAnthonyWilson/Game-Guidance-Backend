using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameGuidanceAPI.Models
{
    public class UserFavorite
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public int GameId { get; set; }

        [MaxLength(200)]
        public string? Name { get; set; }

        [MaxLength(2000)]
        public string? Summary { get; set; }

        public int? Rating { get; set; }
    }
}