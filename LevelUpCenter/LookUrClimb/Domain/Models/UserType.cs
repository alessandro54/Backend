namespace LevelUpCenter.LookUrClimb.Domain.Models;

public class UserType
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string TypeOfUser { get; set; }

    //relationships
    public IList<Publication> Publications = new List<Publication>();
}