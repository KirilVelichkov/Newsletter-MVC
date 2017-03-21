using AutoMapper;
using NewsLetter.Models.DbModels;
using NewsLetter.ViewModels.Articles;

namespace NewsLetter.Services.Providers.Providers
{
    public class BusinessLayerProfile : Profile
    {
        public BusinessLayerProfile()
        {
            CreateMap<CreateArticleViewModel, Article>();
            CreateMap<Article, CreateArticleViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<Article, ListArticleByCategoryViewModel>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Article, SingleArticleViewModel>()
               .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
