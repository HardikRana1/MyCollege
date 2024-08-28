using Abp.Application.Services;
using ProHardikV1.Colleges.Dto;

namespace ProHardikV1.Colleges
{
    public interface ICollegeAppService :
        IAsyncCrudAppService<CollegeDto, int, PagedCollegeResultRequestDto, CreateCollegeDto, UpdateCollegeDto>
    {
    }
}
