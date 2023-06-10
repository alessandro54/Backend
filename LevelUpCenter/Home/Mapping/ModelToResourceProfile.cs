using AutoMapper;
using LevelUpCenter.Home.Domain.Models;
using LevelUpCenter.Home.Resources;

namespace LevelUpCenter.Home.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, UserResource>();
        CreateMap<Publication, PublicationResource>();
    }
}