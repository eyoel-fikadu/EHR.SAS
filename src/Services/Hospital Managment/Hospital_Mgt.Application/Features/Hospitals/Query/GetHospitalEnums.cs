using EHR.SAS.Common.Extensions;
using HospitalMgt.Application.Models;
using HospitalMgt.Domain.Enums;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalMgt.Application.Features.Hospitals.Command
{
    public class GetHospitalEnums : IRequest<List<EnumResponseModel>>
    {

    }

    public class GetHospitalHandler : IRequestHandler<GetHospitalEnums, List<EnumResponseModel>>
    {
        public Task<List<EnumResponseModel>> Handle(GetHospitalEnums request, CancellationToken cancellationToken)
        {
            List<EnumResponseModel> enums = new List<EnumResponseModel>();
            enums.Add(new EnumResponseModel()
            {
                enumKey = nameof(HospitalType),
                enums = EnumExtension.GetList<HospitalType>()
            });

            enums.Add(new EnumResponseModel()
            {
                enumKey = nameof(HospitalClassification),
                enums = EnumExtension.GetList<HospitalClassification>()
            });

            return Task.FromResult(enums);
        }
    }

}
