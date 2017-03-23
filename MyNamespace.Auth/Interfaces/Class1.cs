using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

namespace MyNamespace.Web.Auth.Interfaces
{
    public interface ISignInManager
    {
        Task<SignInStatus> PasswordSignInAsync(string username, string password, bool isPersistent, bool shouldLockout);
    }
}
