using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

namespace MyNamespace.Web.Auth.Interfaces
{
    public interface ISignInManager:IDisposable
    {
        Task<SignInStatus> PasswordSignInAsync(string username, string password, bool isPersistent, bool shouldLockout);
        Task<SignInStatus> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberBrowser);
        Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser);
        Task<bool> HasBeenVerifiedAsync();
        Task<string> GetVerifiedUserIdAsync();
        Task<bool> SendTwoFactorCodeAsync(string provider);
        Task<SignInStatus> ExternalSignInAsync(ExternalLoginInfo externalLoginInfo, bool isPersistent);
    }

}
