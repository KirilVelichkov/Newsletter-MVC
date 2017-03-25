using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NewsLetter.Models.DbModels;
using NewsLetter.Auth.Identity.Managers;
using NewsLetter.ViewModels.Account;
using System.IO;
using NewsLetter.Auth.Identity.Contracts;
using Bytes2you.Validation;

namespace NewsLetter.MVC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAuthService authService;

        public AccountController(IAuthService authService)
        {
            Guard.WhenArgument(authService, nameof(authService)).IsNull().Throw();
            this.authService = authService;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =  this.authService.LogIn(model.Username, model.Password);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid username or password.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userName = model.Username;

                var fileExtension = Path.GetExtension(model.UserAvatar.FileName);
                var imagePath = Server.MapPath($"~/Images/UserAvatars/{userName}");
                var imageName = "avatar" + fileExtension;
                var avatarPicutreUrl = $"/Images/UserAvatars/{userName}/{imageName}";

                Directory.CreateDirectory(imagePath);

                model.UserAvatar.SaveAs(imagePath + imageName);

                var user = new User
                {
                    UserName = model.Username,
                    Email = model.Email,
                    AvatarPictureUrl = avatarPicutreUrl
                };

                var result = await this.authService.Register(user, model.Password);
                if (result.Succeeded)
                {
                     this.authService.LogIn(model.Email, model.Password);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }


        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}