using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameGuidanceAPI.Models
{
    // JsonDeserializer myDeserializedClass = JsonConvert.DeserializeObject<List<JsonDeserializer>>(myJsonResponse);
    public class JsonDeserializer
    {
        public int id { get; set; }
        public int category { get; set; }
        public int created_at { get; set; }
        public List<int> external_games { get; set; }
        public int first_release_date { get; set; }
        public List<int> genres { get; set; }
        public string name { get; set; }
        public List<int> platforms { get; set; }
        public List<int> release_dates { get; set; }
        public List<int> similar_games { get; set; }
        public string slug { get; set; }
        public string summary { get; set; }
        public List<int> tags { get; set; }
        public int updated_at { get; set; }
        public string url { get; set; }
        public string checksum { get; set; }
        public List<int> age_ratings { get; set; }
        public int? cover { get; set; }
        public List<int> involved_companies { get; set; }
        public List<int> screenshots { get; set; }
        public List<int> game_modes { get; set; }
        public List<int> player_perspectives { get; set; }
        public List<int> themes { get; set; }
        public List<int> websites { get; set; }
        public List<int> game_engines { get; set; }
        public List<int> keywords { get; set; }
        public int? status { get; set; }
        public int? collection { get; set; }
        public List<int> franchises { get; set; }
        public List<int> videos { get; set; }
        public int? version_parent { get; set; }
        public string version_title { get; set; }
        public double? aggregated_rating { get; set; }
        public int? aggregated_rating_count { get; set; }
        public List<int> alternative_names { get; set; }
        public int? follows { get; set; }
        public int? franchise { get; set; }
        public double? rating { get; set; }
        public int? rating_count { get; set; }
        public double? total_rating { get; set; }
        public int? total_rating_count { get; set; }
        public List<int> ports { get; set; }
        public List<int> artworks { get; set; }
        public string storyline { get; set; }
        public int? hypes { get; set; }
        public List<int> multiplayer_modes { get; set; }
        public List<int> game_localizations { get; set; }
        public int? parent_game { get; set; }
        public List<int> bundles { get; set; }
    }


}
