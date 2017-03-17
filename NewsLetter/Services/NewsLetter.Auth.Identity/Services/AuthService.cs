using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using NewsLetter.Auth.Identity.Contracts;
using NewsLetter.Auth.Identity.Managers;
using NewsLetter.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Auth.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationSignInManager signInManager;
        private readonly ApplicationUserManager userManager;
        private readonly IAuthenticationManager authManager;

        public AuthService(IOwinContext owinContext)
        {
            Guard.WhenArgument(owinContext, nameof(owinContext)).IsNull().Throw();

            this.signInManager = owinContext.Get<ApplicationSignInManager>();
            this.userManager = owinContext.Get<ApplicationUserManager>();
            this.authManager = owinContext.Authentication;

        }

        public void LogOff()
        {
            this.authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        public async Task<SignInStatus> LogIn(string email, string password)
        {
            SignInStatus result = await this.signInManager.PasswordSignInAsync(email, password, isPersistent: false, shouldLockout: false);

            return result;
        }

        public async Task<IdentityResult> Register(User user, string password)
        {
            var result = await this.userManager.CreateAsync(user, password);

            return result;
        }

        public Task<IdentityResult> ChangePasswordAsync(string v, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public string GetLoggedUserId(IPrincipal loggedUser)
        {
            Guard.WhenArgument(loggedUser, nameof(loggedUser)).IsNull().Throw();

            return loggedUser.Identity.GetUserId();
        }
    }
}
