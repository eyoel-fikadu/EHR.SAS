using EHR.SAS.Common.Controller;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Application.CQRS.Commands.DoctorInsights;
using System;
using System.Threading.Tasks;

namespace Practitioner.API.Controllers
{
    public class DoctorInsightsCommandController : ApiControllerBase
    {
        [HttpPost("AddInsight")]
        public async Task<ActionResult<bool>> AddDoctorInsight(AddDoctorInsightCommand request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost("CreateInsight")]
        public async Task<ActionResult<Guid>> AddDoctorInsight([FromBody] CreateDoctorInsightCommand request)
        {
            return await Mediator.Send(request);
        }
    }
}
