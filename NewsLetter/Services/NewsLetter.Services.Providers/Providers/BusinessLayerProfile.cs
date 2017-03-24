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
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
            CreateMap<Comment, CommentViewModel>()
                    .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.User));
            CreateMap<CommentViewModel, Comment>()
                    .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Author));

            CreateMap<CommentReply, CommentReplyViewModel>()
                   .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.User));

            CreateMap<CommentReplyViewModel, CommentReply>()
                   .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Author));


            CreateMap<Article, ListArticleByCategoryViewModel>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Article, SingleArticleViewModel>()
               .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));


        }
    }
}
