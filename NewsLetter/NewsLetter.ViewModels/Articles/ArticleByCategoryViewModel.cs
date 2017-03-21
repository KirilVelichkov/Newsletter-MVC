using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.ViewModels.Articles
{
    public class ArticleAndCategoryViewModel
    {
        public IEnumerable<ListArticleByCategoryViewModel> ArticlesByCategory { get; set; }

        public string CategoryName { get; set; }
    }
}
