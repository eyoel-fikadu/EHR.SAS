using System;
using System.Threading.Tasks;
using Billing.Service.Features.Billing.Command;
using Billing.Service.Features.Billing.Query;
using Billing.Service.Features.Billing.ViewModel;
using EHR.SAS.Common.Controller;
using Microsoft.AspNetCore.Mvc;

namespace Billing.API.Controllers
{
    public class BillingController : ApiControllerBase
    {
        [HttpGet("{patientId}", Name = "GetBills")]
        public async Task<ActionResult<BillViewModel>> GetUnpaidBillsByUser(Guid patientId)
        {
            return await Mediator.Send(new GetBillCommand() { patientId = patientId });
        }

        //[HttpDelete]
        //public async Task DeleteBills()
        //{

        //}

        [HttpPost]
        public async Task<ActionResult<decimal>> AddBill([FromBody] AddBillCommand command)
        {
            return await Mediator.Send(command);
        }

        //[HttpPost]
        //public void PublishBills()
        //{

        //}

        //[HttpPost]
        //public void CheckoutBills()
        //{

        //}
    }
}
