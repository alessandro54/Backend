namespace LevelUpCenter.LookUrClimb.Domain.Models;

public class Publication
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string UrlImage { get; set; }

    //realtionships
    public int UserId { get; set; }
    public UserType UserType { get; set; }
}