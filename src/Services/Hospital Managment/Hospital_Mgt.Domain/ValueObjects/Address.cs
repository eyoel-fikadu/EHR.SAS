using EHR.SAS.Common.Domain;
using System.Collections.Generic;


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
            yield return Country;
            yield return State;
            yield return City;
            yield return SubCity;
            yield return HouseNumber;
            yield return LocationDescription;
            yield return Longtiued;
            yield return Latitude;
        }
    }
}
