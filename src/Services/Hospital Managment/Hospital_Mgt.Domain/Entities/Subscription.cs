using EHR.SAS.Common.Domain;
using System;


namespace HospitalMgt.Domain.Entities
{
    public class Subscription : HospitalAuditableEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Contract { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public Double Amount { get; set; }
    }
}
