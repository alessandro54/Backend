using AutoMapper;
using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Resources;
using LevelUpCenter.LookUrClimb.Resources.Coach;

namespace LevelUpCenter.LookUrClimb.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Publication, PublicationResource>();
        CreateMap<Game, GameResource>();
        CreateMap<Course, CourseResource>();

        // Coaches
        CreateMap<Coach, SaveCoachResource>();
        CreateMap<Coach, CoachResource>();
    }
}
