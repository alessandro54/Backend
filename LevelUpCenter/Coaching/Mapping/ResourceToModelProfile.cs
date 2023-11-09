using AutoMapper;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Resources;
using LevelUpCenter.Coaching.Resources.Coach;
using LevelUpCenter.Coaching.Resources.Course;
using LevelUpCenter.Coaching.Resources.Game;

namespace LevelUpCenter.Coaching.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePublicationResource, Publication>();
        CreateMap<SaveCourseResource, Course>();
        CreateMap<SaveGameResource, Game>();

        // Coaches
        CreateMap<SaveCoachResource, Coach>();
    }
}
