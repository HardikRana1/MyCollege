using Abp.Application.Services.Dto;

namespace ProHardikV1.Colleges.Dto
{
    public class PagedCollegeResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
