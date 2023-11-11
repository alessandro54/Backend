using LevelUpCenter.Security.Domain.Models;

namespace LevelUpCenter.Coaching.Resources.Learner;

public class SaveLearnerResource
{
    public string Nickname { get; set; } = "";
    public User User { get; set; }
}
