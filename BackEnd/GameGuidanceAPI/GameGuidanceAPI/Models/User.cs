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

        public string? Token { get; set; }

    }
}
