namespace LevelUpCenter.Home.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UrlImage { get; set; }
    
    //relationships
    public IList<Publication> Publications = new List<Publication>();
}