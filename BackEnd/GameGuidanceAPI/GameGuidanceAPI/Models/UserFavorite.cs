using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameGuidanceAPI.Models.IGDB;

namespace GameGuidanceAPI.Models
{
    public class UserFavorite
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int GameId { get; set; }

        public virtual Game? Game { get; set; }

        public virtual User? User { get; set; }
    }
}