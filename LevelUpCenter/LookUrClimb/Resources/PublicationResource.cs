namespace LevelUpCenter.LookUrClimb.Resources;

public class PublicationResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string UrlImage { get; set; }
    public UserTypeResource UserType { get; set; }
}