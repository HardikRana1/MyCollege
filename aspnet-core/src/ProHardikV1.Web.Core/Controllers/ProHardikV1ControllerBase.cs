using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ProHardikV1.Controllers
{
    public abstract class ProHardikV1ControllerBase: AbpController
    {
        protected ProHardikV1ControllerBase()
        {
            LocalizationSourceName = ProHardikV1Consts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
