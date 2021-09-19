using Billing.Infastructure.Entities;
using System;

namespace Billing.Service.Features.Billing.ViewModel
{
    public class BillItemDto
    {
        public Guid HospitalId { get; set; }
        public Guid BranchId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ServiceType { get; set; }
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public Guid ServiceItemId { get; set; }
        public string ServiceItemName { get; set; }

        public BillItemDto()
        {

        }
        public BillItemDto(BillItems items)
        {
            if(items != null)
            {
                HospitalId = items.HospitalId;
                BranchId = items.BranchId;
                Price = items.Price;
                Quantity = items.Quantity;
                ServiceType = items.Type;
                ServiceId = items.ServiceId;
                ServiceName = items.ServiceName;
                ServiceItemId = items.ServiceItemId;
                ServiceItemName = items.ServiceItemName;
            }    
        }
    }
}
