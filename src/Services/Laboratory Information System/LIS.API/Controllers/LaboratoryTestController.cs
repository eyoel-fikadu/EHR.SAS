using EHR.SAS.Common.Controller;
using LIS.Service.CQRS.Features;
using LIS.Service.Features.Query;
using LIS.Service.Features.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace LIS.API.Controllers
{
    public class LaboratoryTestController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LaboratoryViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<LaboratoryViewModel>>> GetLaboratoryTest()
        {
            return await Mediator.Send(new GetLaboratoryTestsCommand());
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<string> CreateLaboratoryTest(AddLaboratoryCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
