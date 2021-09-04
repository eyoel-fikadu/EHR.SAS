using EHR.SAS.Common.Application.Exceptions;
using HospitalMgt.Application.Common.Abstraction;
using HospitalMgt.Application.Features.Hospitals.ViewModel;
using HospitalMgt.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalMgt.Application.Features.Hospitals.Query
{
    public class GetHospitalBranchCommand : IRequest<List<BranchViewModel>>
    {
        public Guid guid { get; set; }
    }

    public class GetHospitalBranchHandler : IRequestHandler<GetHospitalBranchCommand, List<BranchViewModel>>
    {
        private readonly IApplicationDbContext dbContext;

        public GetHospitalBranchHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<BranchViewModel>> Handle(GetHospitalBranchCommand request, CancellationToken cancellationToken)
        {
            var hospital = await dbContext.Hospitals.Include(x => x.HospitalBranches).AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.guid);
            if (hospital == null) throw new NotFoundException(nameof(Hospital),request.guid);
            return hospital.HospitalBranches?.Select(x => new BranchViewModel(x)).ToList();
        }
    }
}
