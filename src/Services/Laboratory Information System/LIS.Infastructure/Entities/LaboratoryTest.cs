using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Infastructure.Entities
{
    public class LaboratoryTest : AuditableEntity
    {
        public Guid HospitalId { get; set; }
        public Guid BranchId { get; set; }
        public string TestName { get; set; }
        public string TestType { get; set; }
        public string ResultType { get; set; }
        public List<LaboratoryPossibleResults> PossibleResults { get; set; }
    }
}
