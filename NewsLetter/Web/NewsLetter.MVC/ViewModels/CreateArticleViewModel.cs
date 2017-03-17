using NewsLetter.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsLetter.MVC.ViewModels
{
    public class CreateArticleViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public IList<Tag> Tags { get; set; }

        public HttpPostedFileBase ArticleImage { get; set; }

    }
}