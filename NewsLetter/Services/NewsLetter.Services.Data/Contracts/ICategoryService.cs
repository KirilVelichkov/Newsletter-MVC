using NewsLetter.Models.DbModels;
using NewsLetter.ViewModels.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Services.Data.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<ListArticleByCategoryViewModel> GetArticleByCategory(string category);

        IEnumerable<CategoryViewModel> GetAllCategories();
    }
}
