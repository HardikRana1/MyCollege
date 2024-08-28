using Abp.AutoMapper;
using ProHardikV1.Models;

namespace ProHardikV1.Colleges.Dto
{
    [AutoMapTo(typeof(College))]
    public class CreateCollegeDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
