using HospitalMgt.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMgt.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string HouseNumber { get; set; }
        public string LocationDescription { get; set; }
        public string Longtiued { get; set; }
        public string Latitude { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
