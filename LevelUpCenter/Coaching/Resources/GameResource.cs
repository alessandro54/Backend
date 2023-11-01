namespace LevelUpCenter.Coaching.Resources;

public class GameResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public string LogoUrl { get; set; }
    public string SplashUrl { get; set; }

    public int ReleaseYear { get; set; }

    public decimal Rating { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
