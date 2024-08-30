using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ProHardikV1.Models;

namespace ProHardikV1.Colleges.Dto
{
    [AutoMapFrom(typeof(College))]
    public class CollegeDto : EntityDto<int>
    {
        public int CollegeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
    }
}
