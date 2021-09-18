using LIS.Infastructure.Repositories.IRepository;
using LIS.Service.Features.ViewModel;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Service.Features.Query
{
    public class GetLaboratoryTestsCommand : IRequest<List<LaboratoryViewModel>>
    {

    }
    public class GetLaboratoryTestsCommandHandler : IRequestHandler<GetLaboratoryTestsCommand, List<LaboratoryViewModel>>
    {
        private readonly ILaboratoryTestRepository _repository;
        private readonly ILogger<GetLaboratoryTestsCommandHandler> _logger;

        public GetLaboratoryTestsCommandHandler(ILaboratoryTestRepository repository, ILogger<GetLaboratoryTestsCommandHandler> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<LaboratoryViewModel>> Handle(GetLaboratoryTestsCommand request, CancellationToken cancellationToken)
        {
            List<LaboratoryViewModel> models = new List<LaboratoryViewModel>();
            var laboratories = await _repository.GetLaboratoryTests();
            foreach(var v in laboratories)
            {
                models.Add(new LaboratoryViewModel(v));
            }
            return models;
        }
    }
}
