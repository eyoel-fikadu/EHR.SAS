using HospitalMgt.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMgt.Domain.Entities
{
    public class Branches : EntityBase
    {
        public string BranchName { get; set; }
        public bool IsMainBranch { get; set; }
    }
}
