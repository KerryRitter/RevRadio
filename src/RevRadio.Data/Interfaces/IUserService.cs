using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using RevRadio.Data.Entities;
using RevRadio.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RevRadio.Data.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetCurrentUser();
        Task<ApplicationUserAccountDetails> GetUserAccountDetails(ApplicationUser user);

        Task<ApplicationUser> FindUserByEmail(string email);
        Task<IdentityResult> ChangePassword(ApplicationUser user, string oldPassword, string newPassword);
        Task<IdentityResult> AddPassword(ApplicationUser user, string newPassword);
        Task<IdentityResult> ResetPassword(string email, string newPassword, string code);
        Task<bool> IsEmailConfirmedAsync(ApplicationUser user);
        Task<IdentityResult> ConfirmEmail(string id, string code);

        Task<IdentityResult> RemoveUserLogin(ApplicationUser user, string loginProvider, string providerKey);
        Task<Tuple<List<UserLoginInfo>, List<AuthenticationDescription>>> GetUserLogins(ApplicationUser user);
        Task<SignInResult> SignIn(string email, string password, bool rememberMe);
        Task SignOut();
        Task<IdentityResult> Register(string email, string password);

        Task<AuthenticationProperties> GetExternalLoginProperties(string provider, string redirectUrl, ApplicationUser user);
        Task<ExternalSignInResult> ExternalSignIn();
        Task<IdentityResult> ExternalRegister(string email);
        Task<IdentityResult> ExternalRegister(ApplicationUser user);
    }
}
