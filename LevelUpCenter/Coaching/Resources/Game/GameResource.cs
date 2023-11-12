using System.Text.Json.Serialization;

namespace LevelUpCenter.Coaching.Resources.Game;

public class GameResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }

    public string SplashUrl { get; set; }
    public string BannerUrl { get; set; }

    public int ReleaseYear { get; set; }

    public decimal Rating { get; set; }

    public DateTime CreatedAt { get; set; }
    [JsonIgnore] public DateTime? UpdatedAt { get; set; }
}
