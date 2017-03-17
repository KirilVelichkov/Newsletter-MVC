using Bytes2you.Validation;
using NewsLetter.Data.Contracts;
using NewsLetter.Models.DbModels;
using NewsLetter.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Services.Data.Services
{
    public class AdminService : BaseDataService, IAdminService
    {
        private readonly IEfGenericRepository<Article> articleRepository;

        public AdminService(IEfGenericRepository<Article> articleRepository, Func<IUnitOfWork> unitOfWork)
            : base(unitOfWork)
        {
            Guard.WhenArgument(articleRepository, nameof(articleRepository)).IsNull().Throw();

            this.articleRepository = articleRepository;
        }

        public void CreateArticle(Article article)
        {
            Guard.WhenArgument(article, nameof(article)).IsNull().Throw();

            using (var uow = base.UnitOfWork())
            {
                this.articleRepository.Add(article);
                uow.Commit();
            }
        }
    }
}
