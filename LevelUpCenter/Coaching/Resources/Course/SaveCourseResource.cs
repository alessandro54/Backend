using System.ComponentModel.DataAnnotations;

namespace LevelUpCenter.Coaching.Resources.Course;

public class SaveCourseResource
{
    [Required] public string title { get; set; }
    [Required] public string description { get; set; }

    [Required] public decimal price { get; set; }

    [Required] public int gameId { get; set; }
    
}
