namespace LevelUpCenter.Coaching.Domain.Models;

public class Enrollment
{
    public int LearnerId { get; set; }
    public Learner Learner { get; set; } = null!;

    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}
