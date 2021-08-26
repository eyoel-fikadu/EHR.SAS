using EHR.SAS.Common.Domain;
using HospitalMgt.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Branches> HospitalBranches { get; set; }
        public List<ContactInformation> HospitalContactInformation { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }
}
