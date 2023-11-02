using AutoMapper;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Resources;
using LevelUpCenter.Coaching.Resources.Coach;
using LevelUpCenter.Coaching.Resources.Game;

namespace LevelUpCenter.Coaching.Mapping;

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
