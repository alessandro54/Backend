using System.Collections.ObjectModel;

namespace LevelUpCenter.Coaching.Domain.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string IconUrl { get; set; } = "";

    public string BannerUrl { get; set; } = "";

    public string SplashUrl { get; set; } = "";

    public int ReleaseYear { get; set; }

    public decimal Rating { get; set; }

    public Collection<Course> Courses { get; set; } = new();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}
