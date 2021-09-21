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
        public Guid CardId { get; set; }
        public string TestName { get; set; }
        public string TestType { get; set; }
        public string ResultType { get; set; }
        public List<string> PossibleResults { get; set; }
        public LaboratoryViewModel(LaboratoryTest test)
        {
            CardId = test.CardId;
            TestName = test.TestName;
            TestType = test.TestType;
            ResultType = test.ResultType;
            PossibleResults = test.PossibleResults.Select(x => x.LabResults).ToList();
        }
    }
}
