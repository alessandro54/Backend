using LevelUpCenter.Security.Resources;

namespace LevelUpCenter.LookUrClimb.Resources.Coach;

public class SaveCoachResource
{
    public string Nickname { get; set; } = "";
    public UserResource User { get; set; }
}
