using NewsLetter.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsLetter.ViewModels.Articles
{
    public class CreateArticleViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string TagNames { get; set; }

        [Required]
        public HttpPostedFileBase ArticleImage { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

    }
}