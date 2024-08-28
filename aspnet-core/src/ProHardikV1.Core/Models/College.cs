using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace ProHardikV1.Models
{
    public class College : FullAuditedEntity<int>, IPassivable
    {
        public College()
        {
            this.IsActive = true;
            this.CreationTime = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
