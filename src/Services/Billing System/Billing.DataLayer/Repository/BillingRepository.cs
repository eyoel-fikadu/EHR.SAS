using Billing.Infastructure.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Infastructure.Repository
{
    public class BillingRepository : IBillingRepository
    {
        private readonly IDistributedCache _redisCache;

        public BillingRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task<decimal> AddBillItems(Guid patientId, List<BillItems> items)
        {
            var bills = await GetBills(patientId);
            bills.BillItems.AddRange(items);
            return await UpdateBills(bills);
        }

        public async Task DeleteBills(Guid patientId)
        {
            await _redisCache.RemoveAsync(patientId.ToString());
        }

        public async Task<Bills> GetBills(Guid patientId)
        {
            var bill = await _redisCache.GetStringAsync(patientId.ToString());
            if(!String.IsNullOrEmpty(bill))
            {
                return JsonConvert.DeserializeObject<Bills>(bill);
            }
            return null;
        }

        public async Task<decimal> UpdateBills(Bills bills)
        {
            await _redisCache.SetStringAsync(bills.PatientId.ToString(), JsonConvert.SerializeObject(bills));

            var bill = await GetBills(bills.PatientId);
            return bill.TotalPrice;
        }
    }
}
