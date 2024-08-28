using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using ProHardikV1.Authorization;
using ProHardikV1.Colleges.Dto;
using ProHardikV1.Models;

namespace ProHardikV1.Colleges
{
    [AbpAuthorize(PermissionNames.Pages_Colleges)]
    public class CollegeAppServiceV2 :
        AsyncCrudAppService<College, CollegeDto, int, PagedCollegeResultRequestDto, CreateCollegeDto, UpdateCollegeDto>,
        ICollegeAppService
    {
        private readonly IRepository<College, int> _collegeRepository;
        private readonly IObjectMapper _objectMapper;

        public CollegeAppServiceV2(
            IRepository<College, int> collegeRepository,
            IObjectMapper objectMapper
        )
            : base(collegeRepository)
        {
            _collegeRepository = collegeRepository;
            _objectMapper = objectMapper;
        }

        public async Task<List<CollegeDto>> GetMyCustomListAsync()
        {
            var colleges = await Repository.GetAllListAsync();
            colleges = colleges.Where(p => p.Id > 1).ToList();
            return _objectMapper.Map<List<CollegeDto>>(colleges);
        }

        public void CreateMyCustomCollegeV1(CreateCollegeDto input)
        {
            var college = _objectMapper.Map<College>(input);
            _collegeRepository.Insert(college);
        }

        public void CreateMyCustomCollegeV2(CreateCollegeDto input)
        {
            var college = new College() { Name = input.Name + "-test", Address = input.Address + "-test" };
            college.Description = input.Description;
            college.Latitude = input.Latitude;
            college.Longitude = input.Longitude;
            college.Email = input.Email;
            college.IsActive = input.IsActive;
            Repository.Insert(college);
        }
    }
}
