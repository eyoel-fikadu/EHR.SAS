using HospitalMgt.Application.Features.Hospitals.Command;
using HospitalMgt.Application.Features.Hospitals.Query;
using HospitalMgt.Application.Features.Hospitals.ViewModel;
using HospitalMgt.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HospitalMgt.API.Controllers
{
    public class HospitalController : ApiControllerBase
    {
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

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(AddHospitalCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateHospitalCommand command)
        {
            if (id != command.id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        //[HttpPut("[action]")]
        //public async Task<ActionResult> UpdateItemDetails(int id, UpdateTodoItemDetailCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await Mediator.Send(command);

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    await Mediator.Send(new DeleteTodoItemCommand { Id = id });

        //    return NoContent();
        //}
    }
}
