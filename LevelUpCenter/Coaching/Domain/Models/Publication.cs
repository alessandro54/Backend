using System.Collections.ObjectModel;

namespace LevelUpCenter.Coaching.Domain.Models;

public class Publication
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string UrlImage { get; set; }

    public Course Course { get; set; }
    public int CourseId { get; set; }

    // Has many Comments
    public Collection<Comment> Comments { get; set; } = new();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}
