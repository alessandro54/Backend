using AutoMapper;
using LevelUpCenter.Home.Domain.Models;
using LevelUpCenter.Home.Resources;

namespace LevelUpCenter.Home.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveUserResource, UserType>();
        CreateMap<SavePublicationResource, Publication>();
    }
}