using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ProHardikV1.Authorization;
using ProHardikV1.Students.Dto;
using ProHardikV1.Models;

namespace ProHardikV1.Students
{

    // [AbpAuthorize(PermissionNames.Pages_Students)]
    public class StudentAppService : AsyncCrudAppService<Student, StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, UpdateStudentDto>, IStudentAppService
    {
        public StudentAppService
        (
            IRepository<Student, int> repository
        )
        : base(repository)
        {

        }

    }
}
