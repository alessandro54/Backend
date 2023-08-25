using AutoMapper;
using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Resources;

namespace LevelUpCenter.LookUrClimb.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePublicationResource, Publication>();
        CreateMap<SaveGameResource, Game>();
    }
}
