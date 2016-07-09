using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RevRadio.Models.ManageViewModels;
using RevRadio.Data.Interfaces;

namespace RevRadio.Controllers
{
    [Authorize]
    public class ManageController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public ManageController(
            IUserService userService,
            ILoggerFactory loggerFactory)
        {
            _userService = userService;
            _logger = loggerFactory.CreateLogger<ManageController>();
        }

        // GET: /Manage/Index
        [HttpGet]
        public async Task<IActionResult> Index(ManageMessageId? message = null)
        {
            ViewData["StatusMessage"] =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

            var user = await _userService.GetCurrentUser();
            if (user == null)
            {
                return View("Error");
            }

            return View(await _userService.GetUserAccountDetails(user));
        }

        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveLogin(RemoveLoginViewModel account)
        {
            var user = await _userService.GetCurrentUser();
            if (user == null)
            {
                return RedirectToAction(nameof(ManageLogins), new { Message = ManageMessageId.Error });
            }

            var result = await _userService.RemoveUserLogin(user, account.LoginProvider, account.ProviderKey);
            if (!result.Succeeded)
            {
                return RedirectToAction(nameof(ManageLogins), new { Message = ManageMessageId.Error });
            }

            return RedirectToAction(nameof(ManageLogins), new { Message = ManageMessageId.RemoveLoginSuccess });
        }

        // GET: /Manage/ChangePassword
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userService.GetCurrentUser();
            if (user == null)
            {
                return RedirectToAction(nameof(Index), new { Message = ManageMessageId.Error });
            }

            var result = await _userService.ChangePassword(user, model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                AddErrors(result);
                return View(model);
            }

            _logger.LogInformation(3, "User changed their password successfully.");
            return RedirectToAction(nameof(Index), new { Message = ManageMessageId.ChangePasswordSuccess });
        }

        // GET: /Manage/SetPassword
        [HttpGet]
        public IActionResult SetPassword()
        {
            return View();
        }

        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userService.GetCurrentUser();
            if (user == null)
            {
                return RedirectToAction(nameof(Index), new { Message = ManageMessageId.Error });
            }

            var result = await _userService.AddPassword(user, model.NewPassword);
            if (!result.Succeeded)
            {
                AddErrors(result);
                return View(model);
            }

            return RedirectToAction(nameof(Index), new { Message = ManageMessageId.SetPasswordSuccess });
        }

        // GET: /Manage/ManageLogins
        [HttpGet]
        public async Task<IActionResult> ManageLogins(ManageMessageId? message = null)
        {
            ViewData["StatusMessage"] =
                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.AddLoginSuccess ? "The external login was added."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            var user = await _userService.GetCurrentUser();
            if (user == null)
            {
                return View("Error");
            }

            var logins = await _userService.GetUserLogins(user);

            ViewData["ShowRemoveButton"] = user.PasswordHash != null || logins.Item1.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = logins.Item1,
                OtherLogins = logins.Item2
            });
        }

        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LinkLogin(string provider)
        {
            var redirectUrl = Url.Action("LinkLoginCallback", "Manage");
            var currentUser = await _userService.GetCurrentUser();
            var properties = await _userService.GetExternalLoginProperties(provider, redirectUrl, currentUser);
            return Challenge(properties, provider);
        }

        // GET: /Manage/LinkLoginCallback
        [HttpGet]
        public async Task<ActionResult> LinkLoginCallback()
        {
            var user = await _userService.GetCurrentUser();
            if (user == null)
            {
                return View("Error");
            }

            var result = await _userService.ExternalRegister(user);
            if (result == null || result.Succeeded == false)
            {
                return RedirectToAction(nameof(ManageLogins), new { Message = ManageMessageId.Error });
            }

            return RedirectToAction(nameof(ManageLogins), new { Message = ManageMessageId.AddLoginSuccess });
        }

        #region Helpers
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            AddLoginSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }
        #endregion
    }
}
