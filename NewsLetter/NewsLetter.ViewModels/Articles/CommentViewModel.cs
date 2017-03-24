using NewsLetter.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.ViewModels.Articles
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int ArticleId { get; set; }

        public IEnumerable<CommentReplyViewModel> Replies { get; set; }

        public UserViewModel Author { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
