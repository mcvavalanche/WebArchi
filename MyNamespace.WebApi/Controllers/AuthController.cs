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
using MyNamespace.DataAccess.Contracts.UnitsOfWork;
using MyNamespace.DataAccess.Model;
using MyNamespace.Web.Auth.Interfaces;
using MyNamespace.WebApi.Models;

namespace MyNamespace.WebApi.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IAuthUnitOfWork _repo;
        private readonly ISignInManager _singInManager;

        public AuthController(IAuthUnitOfWork repo, ISignInManager singInManager)
        {
            _repo = repo;
            _singInManager = singInManager;
        }

        public AspNetRoles Get()
        {
            var r = new AspNetRoles() {Name = "HR"};
            _repo.RolesRepository.Add(r);
            _repo.Save();
            return r;
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
