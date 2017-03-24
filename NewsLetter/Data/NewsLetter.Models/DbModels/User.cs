using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Models.DbModels
{
    public class User : IdentityUser
    {
        private ICollection<Comment> comments;
        private ICollection<CommentReply> commentReplies;

        public User()
        {
            this.comments = new HashSet<Comment>();
            this.commentReplies = new HashSet<CommentReply>();
        }

        public override string Id
        {
            get
            {
                return base.Id;
            }

            set
            {
                base.Id = value;
            }
        }

        public override string UserName
        {
            get
            {
                return base.UserName;
            }

            set
            {
                base.UserName = value;
            }
        }

        public string AvatarPictureUrl { get; set; }

        public virtual ICollection<Comment> Comments {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<CommentReply> CommentReplies
        {
            get { return this.commentReplies; }
            set { this.commentReplies = value; }
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            ClaimsIdentity userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(this.GenerateUserIdentity(manager));
        }
    }
}
