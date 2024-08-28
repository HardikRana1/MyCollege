using System.Threading.Tasks;
using Abp.Application.Services;
using ProHardikV1.Authorization.Accounts.Dto;

namespace ProHardikV1.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
