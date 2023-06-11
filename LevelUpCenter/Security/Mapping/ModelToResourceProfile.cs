using AutoMapper;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Security.Resources;
using LevelUpCenter.Security.Services.Communication;

namespace LevelUpCenter.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
    }
}