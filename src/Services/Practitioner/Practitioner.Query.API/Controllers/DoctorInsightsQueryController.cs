using EHR.SAS.Common.Controller;
using Microsoft.AspNetCore.Mvc;
using Practitioner.Application.CQRS.Query.DoctorInsights;
using Practitioner.Application.CQRS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Query.API.Controllers
{
    public class DoctorInsightsQueryController : ApiControllerBase
    {
        [HttpGet("{cardId}", Name = "GetDoctorInsightByCardId")]
        public async Task<ActionResult<DoctorInsightViewModel>> GetDoctorInsights(Guid cardId)
        {
            return await Mediator.Send(new GetDoctorInsightCommand() { cardId = cardId });
        }
    }
}
