namespace LevelUpCenter.LookUrClimb.Domain.Models;

public class Enrollment
{
    public int ApprenticeId { get; set; }
    public Apprentice Apprentice { get; set; } = null!;

    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}
