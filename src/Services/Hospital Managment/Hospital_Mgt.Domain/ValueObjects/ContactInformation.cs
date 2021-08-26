using EHR.SAS.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMgt.Domain.ValueObjects
{
    public class ContactInformation : ValueObject
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsDefault { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
            yield return Value;
            yield return IsDefault;
        }
    }
}
