using EHR.SAS.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Domain.ValueObjects
{
    public class Insights : ValueObject
    {
        public string Insight { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Insight;
        }
    }
}
