namespace LevelUpCenter.LookUrClimb.Domain.Models;

public class Game
{
    public int Id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string urlImage { get; set; }
    
    //realtionships
    public int UserId { get; set; }
    public UserType UserType { get; set; }
}