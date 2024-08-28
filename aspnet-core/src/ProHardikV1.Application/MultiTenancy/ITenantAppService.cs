using Abp.Application.Services;
using ProHardikV1.MultiTenancy.Dto;

namespace ProHardikV1.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

