using LIS.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Service.Features.ViewModel
{
    public class LaboratoryViewModel
    {
        public Guid HospitalId { get; set; }
        public Guid BranchId { get; set; }
        public string TestName { get; set; }
        public string TestType { get; set; }
        public string ResultType { get; set; }
        public List<LaboratoryPossibleResults> PossibleResults { get; set; }
        public LaboratoryViewModel(LaboratoryTest test)
        {
            HospitalId = test.HospitalId;
            BranchId = test.BranchId;
            TestName = test.TestName;
            TestType = test.TestType;
            ResultType = test.ResultType;
            PossibleResults = test.PossibleResults;
        }
    }
}
