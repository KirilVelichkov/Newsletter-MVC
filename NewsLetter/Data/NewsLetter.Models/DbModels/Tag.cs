using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsLetter.Models.DbModels
{
    public class Tag
    {
        private ICollection<Article> articles;

        public Tag()
        {
            this.articles = new HashSet<Article>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string TagName { get; set; }

        public ICollection<Article> Articles {
            get { return this.articles; }
            set { this.articles = value; }
        }
    }
}