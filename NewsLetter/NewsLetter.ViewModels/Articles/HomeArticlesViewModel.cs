using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.ViewModels.Articles
{
    public class HomeArticlesViewModel
    {
        public IEnumerable<ListArticleByCategoryViewModel> Articles { get; set; }

        public int ArticlesCount { get; set; }

        public int pageNumber { get; set; }

        public int pageSize { get; set; }
    }
}
