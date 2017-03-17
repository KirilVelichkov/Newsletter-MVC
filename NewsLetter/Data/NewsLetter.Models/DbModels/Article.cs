using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Models.DbModels
{
    public class Article
    { 
        private ICollection<Tag> tags;
        private ICollection<Comment> comments;
        public Article()
        {
            this.tags = new HashSet<Tag>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public bool isDeleted { get; set; } = false;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
