using Application.Features.Categories.Queries.GetCategoryList;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile
         : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CategoryId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.CategoryName));
        }
    }
}
