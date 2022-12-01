using Microsoft.Identity.Client;
using GameGuidanceAPI.Models;

namespace GameGuidanceAPI.Models
{
    public class Question
    {
        public bool SinglePlayer { get; set; }
        public bool MultiPlayer { get; set; } 
        public bool CoOp { get; set; }
        public bool Versus { get; set; }
        public bool Standalone { get; set; }
        public bool Series { get; set; }
        public bool FirstPerson { get; set; }
        public bool ThirdPerson { get; set; }
        public double? MinimumRating { get; set; }
        public string[] Genres { get; set; }
        public string[] Themes { get; set; }
        public string[] Keywords { get; set; }
        public List<string> Parameters { get; set; }
    }
}
