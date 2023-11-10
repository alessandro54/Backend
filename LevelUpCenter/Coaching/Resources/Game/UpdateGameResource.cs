using System.ComponentModel.DataAnnotations;

namespace LevelUpCenter.Coaching.Resources.Game;

public class UpdateGameResource
{
    public string? name { get; set; }
    public string? description { get; set; }
    [Url] public string? iconUrl { get; set; }
    [Url] public string? bannerUrl { get; set; }
    [Url] public string? splashUrl { get; set; }
    [Range(2000, 2030)] public int? releaseYear { get; set; }
    [Range(0, 5)] public decimal? rating { get; set; }
}
