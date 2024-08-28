using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ProHardikV1.Authorization;
using ProHardikV1.Colleges.Dto;
using ProHardikV1.Models;

namespace ProHardikV1.Colleges
{
    [AbpAuthorize(PermissionNames.Pages_Colleges)]
    public class CollegeAppService :
        AsyncCrudAppService<College, CollegeDto, int, PagedCollegeResultRequestDto, CreateCollegeDto, UpdateCollegeDto>,
        ICollegeAppService
    {
        public CollegeAppService(
            IRepository<College, int> repository
        )
            : base(repository)
        {
        }
    }
}
