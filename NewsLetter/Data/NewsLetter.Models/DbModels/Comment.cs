using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Models.DbModels
{
    public class Comment
    {
        private ICollection<CommentReply> replies;

        public Comment()
        {
            this.replies = new HashSet<CommentReply>();
        }

        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public virtual User User { get; set; }

        public virtual ICollection<CommentReply> Replies
        {
            get { return this.replies; }
            set { this.replies = value; }
        }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
