using LIS.Infastructure.Repositories.IRepository;
using LIS.Service.Features.ViewModel;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Service.Features.Query
{
    public class GetLaboratoryTestByCardIdCommand : IRequest<LaboratoryViewModel>
    {
        public Guid cardId { get; set; }
    }

    public class GetLaboratoryTestByCardIdCommandHandler : 
        IRequestHandler<GetLaboratoryTestByCardIdCommand, LaboratoryViewModel>
    {
        private readonly ILaboratoryTestRepository _repository;
        private readonly ILogger<GetLaboratoryTestByCardIdCommandHandler> _logger;

        public GetLaboratoryTestByCardIdCommandHandler
            (ILaboratoryTestRepository repository, 
            ILogger<GetLaboratoryTestByCardIdCommandHandler> logger
            )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<LaboratoryViewModel> Handle
            (GetLaboratoryTestByCardIdCommand request, CancellationToken cancellationToken)
        {
            return new LaboratoryViewModel(await _repository.GetLaboratoryTestByCardId(request.cardId));
        }
    }
}
