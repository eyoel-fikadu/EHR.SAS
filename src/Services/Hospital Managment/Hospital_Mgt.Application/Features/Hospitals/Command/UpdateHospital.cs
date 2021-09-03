using HospitalMgt.Application.Common.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalMgt.Application.Features.Hospitals.Command
{
    public class UpdateHospitalCommand : IRequest<bool>
    {
        public Guid id { get; set; }
    }

    public class UpdateHospitalHandler : IRequestHandler<UpdateHospitalCommand, bool>
    {
        private readonly IApplicationDbContext dbContext;

        public UpdateHospitalHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<bool> Handle(UpdateHospitalCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
