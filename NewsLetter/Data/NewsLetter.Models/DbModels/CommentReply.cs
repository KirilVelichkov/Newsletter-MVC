using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsLetter.Models.DbModels
{
    public class CommentReply
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Comment")]
        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }
    }
}