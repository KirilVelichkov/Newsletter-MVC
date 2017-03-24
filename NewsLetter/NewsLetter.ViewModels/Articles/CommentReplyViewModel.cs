using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.ViewModels.Articles
{
    public class CommentReplyViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }
       
        public int CommentId { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public UserViewModel Author { get; set; }

        public string AuthorAvatar { get; set; }
    }
}
