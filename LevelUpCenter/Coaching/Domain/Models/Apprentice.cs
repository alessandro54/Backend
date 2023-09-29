using System.Collections.ObjectModel;
using LevelUpCenter.Security.Domain.Models;

namespace LevelUpCenter.Coaching.Domain.Models;

public class Apprentice
{
    public int Id { get; set; }
    public string Nickname { get; set; } = "";


    public Collection<Enrollment> Enrollments { get; set; } = new();

    public User User { get; set; }
    public int UserId { get; set; }
}
