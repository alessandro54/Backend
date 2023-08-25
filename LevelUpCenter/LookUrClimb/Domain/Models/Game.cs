namespace LevelUpCenter.LookUrClimb.Domain.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; } = "";

    public string LogoUrl { get; set; } = "";

    public int ReleaseYear { get; set; }

    public decimal Rating { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}
