using System.ComponentModel.DataAnnotations;

namespace GameGuidanceAPI.Models.IGDB
{
    public class PlayerPerspective
    {
        [Key]
        public int? Id { get; set; }
        public int? ApiId { get; set; }
        public string? Name { get; set; }
    }
}
