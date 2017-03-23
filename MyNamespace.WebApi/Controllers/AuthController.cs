using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNet.Identity.Owin;
using MyNamespace.DataAccess.Contracts.Repositories;
using MyNamespace.DataAccess.Model;
using MyNamespace.Web.Auth.Interfaces;
using MyNamespace.WebApi.Models;

namespace MyNamespace.WebApi.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IUserRepository _repo;
        private readonly ISignInManager _singInManager;

        public AuthController(IUserRepository repo, ISignInManager singInManager)
        {
            _repo = repo;
            _singInManager = singInManager;
        }

        public AspNetUsers Get()
        {
            var x = _repo.GetAll();
            var u = x.FirstOrDefault();
            return u;
            //return new User {Name = u.UserName, Email = u.Email};
        }


        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<bool> Post([FromBody]User user)
        {
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
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
