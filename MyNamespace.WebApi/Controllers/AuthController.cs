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
        private readonly AppContext _appContext;
        private readonly IBaseUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IUserDetailsRepository _userDetailsRepository;
        private readonly ISignInManager _singInManager;
        private readonly IUserManager _userManager;

        public AuthController(AppContext appContext, IBaseUnitOfWork unitOfWork, IUserRepository userRepository, IUserDetailsRepository userDetailsRepository, ISignInManager singInManager, IUserManager userManager)
        {
            _appContext = appContext;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _userDetailsRepository = userDetailsRepository;
            _singInManager = singInManager;
            _userManager = userManager;

        }

        public bool Get()
        {
            //resolve
            var test = _appContext.Resolve<IUserRepository>();

            //var r = new AspNetRoles() {Name = "HR"};
            //_userUnitOfWork.RolesRepository.Add(r);
            var usr=_userRepository.GetAll().First();
            var ud = new UserDetails()
            {
                Id = 2,
                FirstName = "Bugs34",
                LastName = "Bunny34",
                Address = "rabbit hole no.34",
                UserId = usr.Id
            };
            _userDetailsRepository.AddOrUpdate(ud);
            _unitOfWork.Save();
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
