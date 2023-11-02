using AutoMapper;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Resources;
using LevelUpCenter.Coaching.Resources.Game;

namespace LevelUpCenter.Coaching.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePublicationResource, Publication>();
        CreateMap<SaveGameResource, Game>();
    }
}
