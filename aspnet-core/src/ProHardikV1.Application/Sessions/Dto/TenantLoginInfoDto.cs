using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ProHardikV1.MultiTenancy;

namespace ProHardikV1.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
