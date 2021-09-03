using HospitalMgt.Application.Common.Abstraction;
using HospitalMgt.Application.Features.Hospitals.ViewModel;
using MediatR;
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
            var hospital = await dbContext.Hospitals.FindAsync(request.guid);
            return hospital.HospitalBranches?.Select(x => new BranchViewModel(x)).ToList();
        }
    }

    public class GetHospitalBranchByBranchCommand : IRequest<BranchViewModel>
    {
        public Guid guid { get; set; }
    }

    public class GetHospitalByBranchBranchHandler : IRequestHandler<GetHospitalBranchByBranchCommand, BranchViewModel>
    {
        private readonly IApplicationDbContext dbContext;

        public GetHospitalByBranchBranchHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<BranchViewModel> Handle(GetHospitalBranchByBranchCommand request, CancellationToken cancellationToken)
        {
            var hospital = await dbContext.Hospitals.FindAsync(request.guid);
            return new BranchViewModel(hospital.HospitalBranches?.FirstOrDefault(x => x.Id == request.guid));
        }
    }
}
