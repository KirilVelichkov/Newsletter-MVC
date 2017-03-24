using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.ViewModels.Articles
{
    public class AdminViewModel
    {
        public CreateArticleViewModel CreateArticle { get; set; }

        public IEnumerable<ListArticleByCategoryViewModel> EditArticles { get; set; }
    }
}
