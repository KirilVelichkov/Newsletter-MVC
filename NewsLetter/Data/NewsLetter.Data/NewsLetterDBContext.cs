using Microsoft.AspNet.Identity.EntityFramework;
using NewsLetter.Data.Migrations;
using NewsLetter.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Data
{
    public class NewsLetterDBContext : IdentityDbContext<User>
    {

        public NewsLetterDBContext()
            : base("NewsLetterDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsLetterDBContext, Configuration>());
        }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<CommentReply> CommentReplies { get; set; }

        public static NewsLetterDBContext Create()
        {
            return new NewsLetterDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
        }
    }
}
