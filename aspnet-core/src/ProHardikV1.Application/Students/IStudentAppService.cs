using Abp.Application.Services;
using ProHardikV1.Students.Dto;

namespace ProHardikV1.Students
{
    public interface IStudentAppService : IAsyncCrudAppService<StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, UpdateStudentDto>
    {
      
    }
}

