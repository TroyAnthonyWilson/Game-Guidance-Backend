using System.ComponentModel.DataAnnotations;

namespace GameGuidanceAPI.Models.Game
{
    public class GameMode
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
