using EHR.SAS.Common.Application.Exceptions;
using HospitalMgt.Application.Common.Abstraction;
using HospitalMgt.Application.Features.Hospitals.ViewModel;
using HospitalMgt.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalMgt.Application.Features.Hospitals.Query
{
    public class GetHospitalBranchByBranchIdCommand : IRequest<BranchViewModel>
    {
        public Guid guid { get; set; }
    }

    public class GetHospitalByBranchBranchIdHandler : IRequestHandler<GetHospitalBranchByBranchIdCommand, BranchViewModel>
    {
        private readonly IApplicationDbContext dbContext;

        public GetHospitalByBranchBranchIdHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<BranchViewModel> Handle(GetHospitalBranchByBranchIdCommand request, CancellationToken cancellationToken)
        {
            var branch = await dbContext.HospitalBranches.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(x => x.Id == request.guid);
            if (branch == null) throw new NotFoundException(nameof(Branches), request.guid);
            return new BranchViewModel(branch);
        }
    }
}
