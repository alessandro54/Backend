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
        // Publications
        CreateMap<SavePublicationResource, Publication>();
        // Courses
        CreateMap<SaveCourseResource, Course>();
        // Games
        CreateMap<SaveGameResource, Game>();
        CreateMap<UpdateGameResource, Game>();
        // Coaches
        CreateMap<SaveCoachResource, Coach>();
    }
}
