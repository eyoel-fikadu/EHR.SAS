using EHR.SAS.Common.Domain;
using System;

namespace Billing.Infastructure.Entities
{
    public class BillItems : AuditableEntity
    {
        public Guid HospitalId { get; set; }
        public Guid BranchId { get; set; }
        public decimal Price  { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string ServiceId { get; set; } 
        public string ServiceName { get; set; }
        public Guid ServiceItemId { get; set; }
        public string ServiceItemName { get; set; }
    }
}
