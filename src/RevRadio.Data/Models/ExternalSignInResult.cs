using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace RevRadio.Data.Models
{
    public class ExternalSignInResult
    {
        public bool Succeeded { get; private set; }
        public bool IsLockedOut { get; private set; }
        public string LoginProvider { get; private set; }
        public ClaimsPrincipal Principal { get; private set; }

        public ExternalSignInResult(SignInResult signInResult, ExternalLoginInfo userLoginInfo)
        {
            Succeeded = signInResult.Succeeded;
            IsLockedOut = signInResult.IsLockedOut;
            LoginProvider = userLoginInfo.LoginProvider;
            Principal = userLoginInfo.Principal;
        }
    }
}
