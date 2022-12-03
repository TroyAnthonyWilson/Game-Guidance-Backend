using System.ComponentModel.DataAnnotations;

namespace GameGuidanceAPI.Models.IGDB
{
    public class Genre
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
    }
}
