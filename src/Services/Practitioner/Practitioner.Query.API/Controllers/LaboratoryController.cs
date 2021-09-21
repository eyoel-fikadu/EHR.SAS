using EHR.SAS.Common.Controller;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practitioner.Query.API.Controllers
{
    public class LaboratoryController : ApiControllerBase
    {
        [HttpGet("{cardId}", Name = "GetLabResultsByCardId")]
        public async Task<ActionResult<DoctorInsightViewModel>> GetLabResultsByCardId(Guid cardId)
        {
            //TODO: Consome GRPC but we might not need it
            //Think where i need to use the GRPC


        }
    }
}
