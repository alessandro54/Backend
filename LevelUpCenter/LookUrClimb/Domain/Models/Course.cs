using System.Collections.ObjectModel;

namespace LevelUpCenter.LookUrClimb.Domain.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }


    public int GameId { get; set; }
    public Game Game { get; set; }
    public int CoachId { get; set; }
    public Coach Coach { get; set; }

    public Collection<Enrollment> Enrollments { get; set; } = new();
    public Collection<Publication> Publications { get; set; } = new();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}
