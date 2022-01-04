using AutoMapper;
using ProjectTypeService.Models;
using ProjectTypeService.Dtos;

namespace ProjectTypeService.Profiles
{
    public class ProjectTypeProfile : Profile 
    {
        //ici je configure le mapping entre mon model et mon dto
        public ProjectTypeProfile()
        {
            CreateMap<ProjectType, ProjectTypeReadDto>();
            CreateMap<ProjectTypeCreateDto, ProjectType>();
            CreateMap<ProjectTypeUpdateDto, ProjectType>();
        }
    }
}