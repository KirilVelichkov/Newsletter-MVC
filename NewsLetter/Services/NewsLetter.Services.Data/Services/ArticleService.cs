using Bytes2you.Validation;
using NewsLetter.Data.Contracts;
using NewsLetter.Models.DbModels;
using NewsLetter.Services.Data.Contracts;
using NewsLetter.ViewModels.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Services.Data.Services
{
    public class ArticleService : BaseDataService, IArticleService
    {
        private readonly IEfMappingRepository<Article> articleRepository;
        private readonly IEfMappingRepository<Comment> commentsRepository;
        private readonly IEfMappingRepository<CommentReply> commentsReplyRepository;
        public ArticleService(
                IEfMappingRepository<Article> articleRepository,
                IEfMappingRepository<Comment> commentsRepository,
                IEfMappingRepository<CommentReply> commentsReplyRepository,
                Func<IUnitOfWork> unitOfWork)
            : base(unitOfWork)
        {
            Guard.WhenArgument(articleRepository, nameof(articleRepository)).IsNull().Throw();
            Guard.WhenArgument(commentsRepository, nameof(commentsRepository)).IsNull().Throw();
            Guard.WhenArgument(commentsReplyRepository, nameof(commentsReplyRepository)).IsNull().Throw();

            this.articleRepository = articleRepository;
            this.commentsRepository = commentsRepository;
            this.commentsReplyRepository = commentsReplyRepository;
        }

        public SingleArticleViewModel GetArticleById(int id)
        {
            return this.articleRepository.GetFirstMapped<SingleArticleViewModel>(x => x.Id == id);
        }

        public IEnumerable<ListArticleByCategoryViewModel> GetAllArticles()
        {
            return this.articleRepository.GetAllMapped<ListArticleByCategoryViewModel>();
        }

        public IEnumerable<CommentViewModel> GetArticleComments(int id)
        {
            return this.commentsRepository.GetAllMapped<CommentViewModel>(x => x.ArticleId == id);
        }

        public void AddCommentToArticle(Comment comment)
        {
            using (var uow = base.UnitOfWork())
            {
                this.commentsRepository.Add(comment);
                uow.Commit();
            }
        }

        public void AddCommentReply(CommentReply comment)
        {
            using (var uow = base.UnitOfWork())
            {
                this.commentsReplyRepository.Add(comment);
                uow.Commit();
            }
        }
    }
}
