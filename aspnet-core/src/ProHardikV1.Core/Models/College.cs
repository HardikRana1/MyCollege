using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace ProHardikV1.Models
{
    public class College : FullAuditedEntity<int>/*IEntity<int>*/, IPassivable
    {
        public College()
        {
            this.IsActive = true;
            this.CreationTime = DateTime.Now;
        }
        public int CollegeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
       /* public DateTime CreationTime { get; set; } // Additional properties

        // Implementing the IsTransient method from IEntity<int>
        public bool IsTransient()
        {
            return false;// Id == 0;
        }*/
    }
}
