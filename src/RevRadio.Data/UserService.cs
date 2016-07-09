using Microsoft.AspNetCore.Identity;
using RevRadio.Data.Entities;
using RevRadio.Data.Interfaces;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http.Authentication;
using RevRadio.Data.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;

namespace RevRadio.Data
{
    internal class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        }

        public async Task<ApplicationUserAccountDetails> GetUserAccountDetails(ApplicationUser user)
        {
            return new ApplicationUserAccountDetails
            {
                HasPassword = await _userManager.HasPasswordAsync(user),
                PhoneNumber = await _userManager.GetPhoneNumberAsync(user),
                TwoFactor = await _userManager.GetTwoFactorEnabledAsync(user),
                Logins = await _userManager.GetLoginsAsync(user),
                BrowserRemembered = await _signInManager.IsTwoFactorClientRememberedAsync(user)
            };
        }

        public async Task<ApplicationUser> FindUserByEmail(string email)
        {
            return await _userManager.FindByNameAsync(email);
        }

        public async Task<bool> IsEmailConfirmedAsync(ApplicationUser user)
        {
            return await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<IdentityResult> ConfirmEmail(string id, string code)
        {
            if (id == null || code == null)
            {
                return null;
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            return await _userManager.ConfirmEmailAsync(user, code);
        }

        public async Task<IdentityResult> RemoveUserLogin(ApplicationUser user, string loginProvider, string providerKey)
        {
            var result = await _userManager.RemoveLoginAsync(user, loginProvider, providerKey);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            return result;
        }

        public async Task<IdentityResult> ChangePassword(ApplicationUser user, string oldPassword, string newPassword)
        {
            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            return result;
        }

        public async Task<IdentityResult> AddPassword(ApplicationUser user, string newPassword)
        {
            var result = await _userManager.AddPasswordAsync(user, newPassword);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            return result;
        }

        public async Task<IdentityResult> ResetPassword(string email, string newPassword, string code)
        {
            var user = await FindUserByEmail(email);
            if (user != null)
            {
                return await _userManager.ResetPasswordAsync(user, code, newPassword);
            }
            else
            {
                return null;
            }
        }

        public async Task<Tuple<List<UserLoginInfo>, List<AuthenticationDescription>>> GetUserLogins(ApplicationUser user)
        {
            var userLogins = await _userManager.GetLoginsAsync(user);
            var otherLogins = _signInManager.GetExternalAuthenticationSchemes().Where(auth => userLogins.All(ul => auth.AuthenticationScheme != ul.LoginProvider));

            return new Tuple<List<UserLoginInfo>, List<AuthenticationDescription>>(userLogins.ToList(), otherLogins.ToList());
        }

        public async Task<SignInResult> SignIn(string email, string password, bool rememberMe)
        {
            return await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: false);
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(string email, string password)
        {
            var user = new ApplicationUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }

        public async Task<AuthenticationProperties> GetExternalLoginProperties(string provider, string redirectUrl, ApplicationUser user)
        {
            var userId = user == null ? null : await _userManager.GetUserIdAsync(user);

            return _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl, userId);
        }

        public async Task<ExternalSignInResult> ExternalSignIn()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                return null;
            }

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);

            return new ExternalSignInResult(result, info);
        }

        public async Task<IdentityResult> ExternalRegister(string email)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return null;
            }

            var user = new ApplicationUser { UserName = email, Email = email };

            var createResult = await _userManager.CreateAsync(user);

            if (createResult.Succeeded)
            {
                var loginResult = await _userManager.AddLoginAsync(user, info);

                if (loginResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                }

                return loginResult;
            }

            return createResult;
        }

        public async Task<IdentityResult> ExternalRegister(ApplicationUser user)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync(await _userManager.GetUserIdAsync(user));
            if (info == null)
            {
                return null;
            }
            return await _userManager.AddLoginAsync(user, info);
        }
    }
}
