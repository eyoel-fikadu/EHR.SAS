using EHR.SAS.Common.Controller;
using EHR.SAS.Common.Extensions;
using HospitalMgt.Application.Features.Hospitals.Command;
using HospitalMgt.Application.Features.Hospitals.Query;
using HospitalMgt.Application.Features.Hospitals.ViewModel;
using HospitalMgt.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalMgt.API.Controllers
{
    public class HospitalController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(AddHospitalCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<bool>> Update(Guid id, UpdateHospitalCommand command)
        {
            if (id != command.id)
            {
                return BadRequest();
            }
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<HospitalViewModel>>> GetHospitalsWithPagination([FromQuery] GetAllHospitalsCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<HospitalViewModel>> GetHospitalById(Guid guid)
        {
            return await Mediator.Send(new GetHospitalCommand() { guid = guid });
        }

        [HttpGet("getHospitalEnums")]
        public async Task<ActionResult<List<EnumResponseModel>>> GetEnums()
        {
            return await Mediator.Send(new GetHospitalEnums());
        }

    }
}
