using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MyNamespace.DataAccess.Contracts.Repositories;
using MyNamespace.DataAccess.Contracts.UnitsOfWork;
using MyNamespace.DataAccess.Model;
using MyNamespace.Web.Auth;
using MyNamespace.Web.Auth.Interfaces;
using MyNamespace.WebApi.Models;

namespace MyNamespace.WebApi.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IUserUnitOfWork _userUnitOfWork;
        private readonly ISignInManager _singInManager;
        private readonly IUserManager _userManager;

        public AuthController(IUserUnitOfWork userUnitOfWork, ISignInManager singInManager, IUserManager userManager)
        {
            _userUnitOfWork = userUnitOfWork;
            _singInManager = singInManager;
            _userManager = userManager;
        }

        public bool Get()
        {
            //var r = new AspNetRoles() {Name = "HR"};
            //_userUnitOfWork.RolesRepository.Add(r);
            var usr=_userUnitOfWork.UserRepository.GetAll().First();
            var ud = new UserDetails()
            {
                Id = 2,
                FirstName = "Bugs2",
                LastName = "Bunny2",
                Address = "rabbit hole no.2",
                //UserId = usr.Id
            };
            _userUnitOfWork.UserDetailsRepository.Add(ud);
            _userUnitOfWork.Save();
            return true;
        }


        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<bool> Post([FromBody]User user)
        {
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            ApplicationUser signedUser = await _userManager.FindByNameAsync(user.Name);
            var result = await _singInManager.PasswordSignInAsync(user.Name, user.Password, false, false);
            switch (result)
            {
                case SignInStatus.Success:
                    return true;
                //case SignInStatus.LockedOut:
                //    return View("Lockout");
                //case SignInStatus.RequiresVerification:
                //    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                //case SignInStatus.Failure:
                //default:
                //    ModelState.AddModelError("", "Invalid login attempt.");
                //    return View(model);
            }
            return false;
        }

    }
}
