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
        public ArticleService(
                IEfMappingRepository<Article> articleRepository,
                Func<IUnitOfWork> unitOfWork)
            : base(unitOfWork)
        {
            Guard.WhenArgument(articleRepository, nameof(articleRepository)).IsNull().Throw();

            this.articleRepository = articleRepository;
        }

        public SingleArticleViewModel GetArticleById(int id)
        {
         return this.articleRepository.GetFirstMapped<SingleArticleViewModel>(x => x.Id == id);
        }
    }
}
