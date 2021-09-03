using EHR.SAS.Common.Domain;
using HospitalMgt.Domain.ValueObjects;
using System.Collections.Generic;

namespace HospitalMgt.Domain.Entities
{
    public class Hospital : AuditableEntity
    {
        //https://www.vedantu.com/biology/hospital
        public string  Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Type { get; set; }//Publicly owned , Non profit, For profit 
        public string TypeOfCare { get; set; }
        public ICollection<Branches> HospitalBranches { get; set; }
        public ICollection<ContactInformation> HospitalContactInformation { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
