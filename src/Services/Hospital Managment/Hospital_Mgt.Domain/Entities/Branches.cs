using EHR.SAS.Common.Domain;
using HospitalMgt.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMgt.Domain.Entities
{
    public class Branches : AuditableEntity
    {
        public string BranchName { get; set; }
        public bool IsMainBranch { get; set; }
        public Address Address { get; set; }

    }
}
