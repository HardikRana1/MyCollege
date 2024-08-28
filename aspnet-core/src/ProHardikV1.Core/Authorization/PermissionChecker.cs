using Abp.Authorization;
using ProHardikV1.Authorization.Roles;
using ProHardikV1.Authorization.Users;

namespace ProHardikV1.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
