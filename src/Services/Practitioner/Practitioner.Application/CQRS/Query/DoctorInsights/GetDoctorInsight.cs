using MediatR;
using Microsoft.Extensions.Logging;
using Practitioner.Application.Common.Abstraction;
using Practitioner.Application.CQRS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practitioner.Application.CQRS.Query.DoctorInsights
{
    public class GetDoctorInsightCommand : IRequest<DoctorInsightViewModel>
    {
        public Guid cardId { get; set; }
    }

    public class GetDoctorInsightCommandHandler : IRequestHandler<GetDoctorInsightCommand, DoctorInsightViewModel>
    {
        private readonly IReadRepository _repository;
        private readonly ILogger<GetDoctorInsightCommand> _logger;

        public GetDoctorInsightCommandHandler(IReadRepository repository, ILogger<GetDoctorInsightCommand> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<DoctorInsightViewModel> Handle(GetDoctorInsightCommand request, CancellationToken cancellationToken)
        {
            return new DoctorInsightViewModel(await _repository.GetDoctorInsightByCardId(request.cardId));
        }
    }
}
