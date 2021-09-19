using Billing.Infastructure.Entities;
using Billing.Infastructure.Repository;
using Billing.Service.Features.Billing.ViewModel;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Billing.Service.Features.Billing.Command
{
    public class AddBillCommand : IRequest<decimal>
    {
        public Guid PatientId { get; set; }
        public List<BillItemDto> billLists { get; set; }
    }

    public class AddBillCommandHandler : IRequestHandler<AddBillCommand, decimal>
    {
        private readonly IBillingRepository _billingRepository;
        private ILogger<AddBillCommandHandler> _logger;

        public AddBillCommandHandler(IBillingRepository billingRepository, ILogger<AddBillCommandHandler> logger)
        {
            this._billingRepository = billingRepository ?? throw new ArgumentNullException(nameof(billingRepository));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<decimal> Handle(AddBillCommand request, CancellationToken cancellationToken)
        {
            var bills = new Bills()
            {
                PatientId = request.PatientId,
            };
            request.billLists.ForEach(x => bills.BillItems.Add(new BillItems()
            {
                BranchId = x.BranchId,
                HospitalId = x.HospitalId,
                Price = (decimal)x.Price,
                Quantity = x.Quantity,
                ServiceId = x.ServiceId,
                ServiceName = x.ServiceName,
                Type = x.ServiceType,
                ServiceItemId = x.ServiceItemId,
                ServiceItemName = x.ServiceItemName
            }));

            return _billingRepository.UpdateBills(bills);
        }
    }
}
