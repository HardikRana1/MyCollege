using System.Threading.Tasks;
using Abp.Application.Services;
using ProHardikV1.Sessions.Dto;

namespace ProHardikV1.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
