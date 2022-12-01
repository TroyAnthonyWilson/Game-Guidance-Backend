using System.ComponentModel.DataAnnotations;

namespace GameGuidanceAPI.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(60)]
        public string Password { get; set; }

        [MaxLength(400)]
        public string? Token { get; set; }

        //public string[]? Platforms { get; set; }
        //[Required]
        //[MaxLength(3)]
        //public int Age { get; set; }
        //public string[]? Languages { get; set; }
        //public string[]? FavoriteGames { get; set; }
        //public string[]? IgnoredGames { get; set; }

    }
}
