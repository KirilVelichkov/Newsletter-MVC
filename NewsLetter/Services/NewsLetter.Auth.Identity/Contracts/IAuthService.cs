using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using NewsLetter.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Auth.Identity.Contracts
{
    public interface IAuthService
    {
        void LogOff();

        SignInStatus LogIn(string email, string password);

        Task<IdentityResult> Register(User user, string password);

        Task<IdentityResult> ChangePasswordAsync(string v, string oldPassword, string newPassword);

        string GetLoggedUserId(IPrincipal loggedUser);
    }
}
