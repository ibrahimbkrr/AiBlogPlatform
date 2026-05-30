using System.Runtime;
using AutoMapper;
using BtkAkademiAi.WebApi.Dtos.ArticleDtos;
using BtkAkademiAi.WebApi.Entities;
namespace BtkAkademiAi.WebApi.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
                    CreateMap<Article, ResultArticleWithCategoryDto>()
              .ForMember(dest => dest.CategoryName,
                  opt => opt.MapFrom(src => src.Category.CategoryName))
              .ForMember(dest => dest.AuthorName,
                  opt => opt.MapFrom(src => src.AppUser.Name))
              .ForMember(dest => dest.AuthorSurname,
                  opt => opt.MapFrom(src => src.AppUser.Surname))
              .ForMember(dest => dest.AuthorImageUrl,
                  opt => opt.MapFrom(src => src.AppUser.ImageUrl));

                    CreateMap<Article, ResultLastTechnologyDto>()
            .ForMember(dest => dest.AuthorName,
                opt => opt.MapFrom(src => src.AppUser.Name))
            .ForMember(dest => dest.AuthorSurname,
                opt => opt.MapFrom(src => src.AppUser.Surname))
            .ForMember(dest => dest.AuthorImageUrl,
                opt => opt.MapFrom(src => src.AppUser.ImageUrl))
            .ForMember(dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.Category.CategoryName));


                CreateMap<Article, ResultLastEgitimDto>()
               .ForMember(dest => dest.AuthorName,
                   opt => opt.MapFrom(src => src.AppUser.Name))
               .ForMember(dest => dest.AuthorSurname,
                   opt => opt.MapFrom(src => src.AppUser.Surname))
               .ForMember(dest => dest.AuthorImageUrl,
                   opt => opt.MapFrom(src => src.AppUser.ImageUrl))
               .ForMember(dest => dest.CategoryName,
                   opt => opt.MapFrom(src => src.Category.CategoryName));


            CreateMap<Article, ResultLastSportsDto>()
               .ForMember(dest => dest.AuthorName,
                   opt => opt.MapFrom(src => src.AppUser.Name))
               .ForMember(dest => dest.AuthorSurname,
                   opt => opt.MapFrom(src => src.AppUser.Surname))
               .ForMember(dest => dest.AuthorImageUrl,
                   opt => opt.MapFrom(src => src.AppUser.ImageUrl))
               .ForMember(dest => dest.CategoryName,
                   opt => opt.MapFrom(src => src.Category.CategoryName));

            CreateMap<Article, LastArticleByCategoryDto>()
                .ForMember(dest => dest.CategoryName,
                     opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.SliderCategoryImageUrl,
                     opt => opt.MapFrom(src => src.SliderCategoryImageUrl));

            CreateMap<Article, CreateArticleDto>().ReverseMap();

                    CreateMap<Article, UpdateArticleDto>().ReverseMap();

                    CreateMap<Article, GetArticleByIdDto>().ReverseMap();


        }
    }
}
