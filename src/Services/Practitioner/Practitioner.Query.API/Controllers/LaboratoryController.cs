using EHR.SAS.Common.Controller;
using LIS.Grpc.Protos;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Query.API.GrpcServices;
using System;
using System.Threading.Tasks;

namespace Practitioner.Query.API.Controllers
{
    public class LaboratoryController : ApiControllerBase
    {
        private readonly LaboratoryGrpcService _grpcService;

        public LaboratoryController(LaboratoryGrpcService grpcService)
        {
            _grpcService = grpcService ?? throw new ArgumentNullException(nameof(grpcService));
        }

        [HttpGet("{cardId}", Name = "GetLabResultsByCardId")]
        public async Task<ActionResult<LaboratoryModel>> GetLabResultsByCardId(Guid cardId)
        {
            //TODO: Consome GRPC but we might not need it here
            //Think where i need to use the GRPC

            return await _grpcService.GetLaboratoryModel(cardId);
        }
    }
}
