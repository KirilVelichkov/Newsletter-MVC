using NewsLetter.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.ViewModels.Articles
{
     public class SingleArticleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
