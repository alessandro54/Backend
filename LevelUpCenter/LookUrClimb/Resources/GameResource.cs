namespace LevelUpCenter.LookUrClimb.Resources;

public class GameResource
{
    public int Id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string urlImage { get; set; }
    public UserTypeResource UserType { get; set; }
}