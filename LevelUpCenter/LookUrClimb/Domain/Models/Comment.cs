using LevelUpCenter.Security.Domain.Models;

namespace LevelUpCenter.LookUrClimb.Domain.Models;

public class Comment
{
    public Guid Id { get; set; }
    public string Content { get; set; } = "";

    public Guid? ParentId { get; set; }
    public Comment? Parent { get; set; }


    public int AuthorId { get; set; }
    public User Author { get; set; } = null!;

    public int PublicationId { get; set; }
    public Publication Publication { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}
