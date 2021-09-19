using Billing.Infastructure.Entities;
using System;
using System.Collections.Generic;

namespace Billing.Service.Features.Billing.ViewModel
{
    public class BillViewModel
    {
        public Guid PatientId { get; set; }
        public decimal TotalPrice { get; }
        public List<BillItemDto> BillItems { get; set; } = new List<BillItemDto>();
        public BillViewModel(Bills bills)
        {
            if(bills != null)
            {
                PatientId = bills.PatientId;
                TotalPrice = bills.TotalPrice;
                bills.BillItems.ForEach(x => BillItems.Add(new BillItemDto(x)));
            }
        }
    }
}
