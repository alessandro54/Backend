namespace LevelUpCenter.Home.Resources;

public class PublicationResource
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string UrlImage { get; set; }
    public UserResource User { get; set; }
}