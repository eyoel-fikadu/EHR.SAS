using Billing.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Infastructure.Repository
{
    public interface IBillingRepository
    {
        Task<Bills> GetBills(Guid patientId);
        Task<decimal> UpdateBills(Bills bills);
        Task DeleteBills(Guid patientId);
        Task<decimal> AddBillItems(Guid patientId, List<BillItems> items);
    }
}
