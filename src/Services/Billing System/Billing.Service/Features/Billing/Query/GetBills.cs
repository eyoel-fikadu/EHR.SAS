using Billing.Infastructure.Repository;
using Billing.Service.Features.Billing.ViewModel;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Billing.Service.Features.Billing.Query
{
    public class GetBillCommand : IRequest<BillViewModel>
    {
        public Guid patientId { get; set; }
    }

    public class GetBillCommandHandler : IRequestHandler<GetBillCommand, BillViewModel>
    {
        private readonly IBillingRepository _billingRepository;
        private ILogger<GetBillCommandHandler> _logger;

        public GetBillCommandHandler(IBillingRepository billingRepository, ILogger<GetBillCommandHandler> logger)
        {
            _billingRepository = billingRepository ?? throw new ArgumentNullException(nameof(billingRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<BillViewModel> Handle(GetBillCommand request, CancellationToken cancellationToken)
        {
            var bill = await _billingRepository.GetBills(request.patientId);
            return new BillViewModel(bill);
        }
    }
}
