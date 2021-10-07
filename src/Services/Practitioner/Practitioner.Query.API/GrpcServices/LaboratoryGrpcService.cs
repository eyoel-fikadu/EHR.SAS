using LIS.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Query.API.GrpcServices
{
    public class LaboratoryGrpcService
    {
        private readonly LaboratoryProtoService.LaboratoryProtoServiceClient _labProtoServices;

        public LaboratoryGrpcService(LaboratoryProtoService.LaboratoryProtoServiceClient labProtoServices)
        {
            _labProtoServices = labProtoServices ?? throw new ArgumentNullException(nameof(labProtoServices));
        }

        public async Task<LaboratoryModel> GetLaboratoryModel(Guid cardId)
        {
            var request = new GetLabResultByCardIdRequest() { CardId = new UUID() { Value = cardId.ToString() } };

            return await _labProtoServices.GetPatientLaboratoryResultsAsync(request);
        }
    }
}
