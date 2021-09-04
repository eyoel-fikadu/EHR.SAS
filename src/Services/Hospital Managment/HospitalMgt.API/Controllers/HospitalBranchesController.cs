using HospitalMgt.Application.Features.Hospitals.Command;
using HospitalMgt.Application.Features.Hospitals.Query;
using HospitalMgt.Application.Features.Hospitals.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalMgt.API.Controllers
{
    public class HospitalBranchesController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(AddHospitalBranchCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("getByHospital/{id}")]
        public async Task<ActionResult<List<BranchViewModel>>> GetBranchesByHospitalId(Guid id)
        {
            return await Mediator.Send(new GetHospitalBranchCommand() { guid = id});
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<BranchViewModel>> GetClientById(Guid guid)
        {
            return await Mediator.Send(new GetHospitalBranchByBranchIdCommand() { guid = guid });
        }

        [HttpPut("{guid}")]
        public async Task<ActionResult<bool>> Update(Guid guid, UpdateBranchCommand request)
        {
            if(guid != request.id)
            {
               return BadRequest();
            }
            return await Mediator.Send(request);
        }
       
    }
}
