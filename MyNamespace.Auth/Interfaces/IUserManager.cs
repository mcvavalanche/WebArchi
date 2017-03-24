using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace MyNamespace.Web.Auth.Interfaces
{
    public interface IUserManager : IDisposable
    {
        Task<ApplicationUser> FindByNameAsync(string username);
        Task<bool> IsEmailConfirmedAsync(string userId);
        Task<IdentityResult> CreateAsync(ApplicationUser user);
        Task<IdentityResult> UpdateAsync(ApplicationUser user);
        Task<IdentityResult> AddToRoleAsync(string userId, string role);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);
        Task<IdentityResult> AddPasswordAsync(string userId, string password);
        Task<IdentityResult> ConfirmEmailAsync(string userId, string token);
        Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword);
        Task<IList<string>> GetValidTwoFactorProvidersAsync(string userId);
        Task<IList<string>> GetRolesAsync(string userId);
        Task<ApplicationUser> FindByIdAsync(string userId);
        Task<string> GenerateChangePhoneNumberTokenAsync(string userId, string phoneNumber);
        Task<IdentityResult> SetTwoFactorEnabledAsync(string userId, bool enabled);
        Task<IdentityResult> ChangePhoneNumberAsync(string userId, string phoneNumber, string token);
        Task<IdentityResult> ChangePasswordAsync(string userId, string password, string newPassword);
        Task<IdentityResult> SetPhoneNumberAsync(string userId, string phoneNumber);
        Task<string> GetPhoneNumberAsync(string userId);
        Task<bool> GetTwoFactorEnabledAsync(string userId);
        Task<IList<UserLoginInfo>> GetLoginsAsync(string userId);
        Task<IdentityResult> RemoveLoginAsync(string userId, UserLoginInfo login);
        IIdentityMessageService SmsService { get; set; }
        Task<string> GeneratePasswordResetTokenAsync(string userId);
        Task SendEmailAsync(string userId, string subject, string body);
        Task<string> GenerateEmailConfirmationTokenAsync(string userId);
    }
}
