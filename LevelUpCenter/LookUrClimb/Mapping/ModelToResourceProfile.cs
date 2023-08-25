using AutoMapper;
using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Resources;

namespace LevelUpCenter.LookUrClimb.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Publication, PublicationResource>();
        CreateMap<Game, GameResource>();
    }
}
