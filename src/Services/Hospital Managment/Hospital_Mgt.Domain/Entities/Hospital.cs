using EHR.SAS.Common.Domain;
using HospitalMgt.Domain.Enums;
using HospitalMgt.Domain.ValueObjects;
using System.Collections.Generic;

namespace HospitalMgt.Domain.Entities
{
    public class Hospital : HospitalAuditableEntity
    {
        //https://www.vedantu.com/biology/hospital
        //https://www.gallaghermalpractice.com/blog/post/what-are-the-different-types-of-hospitals
        public string  Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public HospitalType Type { get; set; }//Publicly owned , Non profit, For profit 
        public HospitalClassification Classification { get; set; }
        public ICollection<Branches> HospitalBranches { get; set; }
        public ICollection<ContactInformation> HospitalContactInformation { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
