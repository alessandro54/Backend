using AutoMapper;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Resources;

namespace LevelUpCenter.Coaching.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePublicationResource, Publication>();
        CreateMap<SaveGameResource, Game>();
    }
}
