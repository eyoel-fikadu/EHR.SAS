using LIS.Infastructure.Entities;
using LIS.Infastructure.Repositories.IRepository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIS.Service.CQRS.Features
{
    public class AddLaboratoryCommand : IRequest<string>
    {
        public Guid CardId { get; set; }
        public string TestName { get; set; }
        public string TestType { get; set; }
        public string ResultType { get; set; }
    }

    public class AddLaboratoryCommandHandler : IRequestHandler<AddLaboratoryCommand, string>
    {
        private readonly ILaboratoryTestRepository _repository;
        private readonly ILogger<AddLaboratoryCommandHandler> _logger;

        public AddLaboratoryCommandHandler(ILaboratoryTestRepository repository, ILogger<AddLaboratoryCommandHandler> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> Handle(AddLaboratoryCommand request, CancellationToken cancellationToken)
        {
            var laboratoryTest = new LaboratoryTest()
            {
                CardId = request.CardId,
                ResultType = request.ResultType,
                TestName = request.TestName,
                TestType = request.TestType
            };

            await _repository.CreateLaboratoryTest(laboratoryTest);

            return laboratoryTest.Id;
        }
    }
}
