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
    public class CategoryService : BaseDataService, ICategoryService
    {
        private readonly IEfMappingRepository<Article> articleRepository;
        private readonly IEfMappingRepository<Category> categoryRepository;

        public CategoryService(
            IEfMappingRepository<Article> articleRepository,
            IEfMappingRepository<Category> categoryRepository,
            Func<IUnitOfWork> unitOfWork) : base(unitOfWork)
        {
            Guard.WhenArgument(articleRepository, nameof(articleRepository)).IsNull().Throw();
            Guard.WhenArgument(categoryRepository, nameof(categoryRepository)).IsNull().Throw();

            this.categoryRepository = categoryRepository;
            this.articleRepository = articleRepository;
        }

        public IEnumerable<ListArticleByCategoryViewModel> GetArticleByCategory(string category)
        {
            return this.articleRepository.GetAllMapped<ListArticleByCategoryViewModel>(x => x.Category.Name.ToLower() == category.ToLower());
        }

        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            return this.categoryRepository.GetAllMapped<CategoryViewModel>();
        }
    }
}
