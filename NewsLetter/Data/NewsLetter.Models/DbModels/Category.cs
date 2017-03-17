using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsLetter.Models.DbModels
{
    public class Category
    {
        private ICollection<Article> articles;

        public Category()
        {
            this.articles = new HashSet<Article>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }
    }
}