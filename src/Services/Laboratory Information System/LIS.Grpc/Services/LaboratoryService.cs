using EHR.SAS.Common.Application.Exceptions;
using Grpc.Core;
using LIS.Grpc.Protos;
using LIS.Service.Features.Query;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIS.Grpc.Services
{
    public class LaboratoryService : LaboratoryProtoService.LaboratoryProtoServiceBase
    {
        private readonly ISender _mediator;
        private readonly ILogger<LaboratoryService> _logger;

        public LaboratoryService(ISender mediator, ILogger<LaboratoryService> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override async Task<LaboratoryModel> GetPatientLaboratoryResults
            (GetLabResultByCardIdRequest request, ServerCallContext context)
        {
            Guid cardId = Guid.Empty;
            if (Guid.TryParse(request.CardId.Value, out cardId))
            {
                var history = await _mediator.Send(new GetLaboratoryTestByCardIdCommand() { cardId = cardId });
                if(history == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound,
                        $"Laboratoty result with card id {request.CardId.Value} is not found"));
                }
                var lab = new LaboratoryModel()
                {
                    Card = new UUID() { Value = history.CardId.ToString() },
                    ResultType = history.ResultType,
                    TestName = history.TestName,
                    TestType = history.TestType
                };
                var test = new TestResults();
                test.Result.AddRange(history.PossibleResults);
                lab.Results = test;

                return lab;
            }
            throw new RpcException(new Status(StatusCode.InvalidArgument, $"Invalid card id {request.CardId.Value}"));
        }
    }
}
