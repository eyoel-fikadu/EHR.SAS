using System;
using System.Collections.Generic;

namespace Billing.Infastructure.Entities
{
    public class Bills
    {
        public Guid PatientId { get; set; }
        public List<BillItems> BillItems { get; set; } = new List<BillItems>();

        public Bills()
        {
        }

        public Bills(Guid patientId)
        {
            PatientId = patientId;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                BillItems?.ForEach(x => totalPrice += x.Quantity * x.Price);
                return totalPrice;
            }
        }
    }
}
