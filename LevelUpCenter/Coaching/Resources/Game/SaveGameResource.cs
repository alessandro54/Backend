using System.ComponentModel.DataAnnotations;

namespace LevelUpCenter.Coaching.Resources.Game;

public class SaveGameResource
{
    [Required] public string name { get; set; }
    [Required] public string description { get; set; }
    [Required] [Url] public string iconUrl { get; set; }
    [Url] public string bannerUrl { get; set; }
    [Required] [Url] public string splashUrl { get; set; }
    [Range(2000, 2030)] public int releaseYear { get; set; }
    [Range(0, 5)] public decimal rating { get; set; }
}
