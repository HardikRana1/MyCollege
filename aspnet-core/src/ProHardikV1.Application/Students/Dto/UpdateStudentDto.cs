using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ProHardikV1.Models;

namespace ProHardikV1.Students.Dto
{
    [AutoMapTo(typeof(Student))]
    public class UpdateStudentDto : EntityDto<int>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ProgramName { get; set; }
        public string DoB { get; set; }
        public bool IsActive { get; set; }

        public int CollegeId { get; set; }
        ///UpdateDto.cs.fields1///

    }
}

