using EHR.SAS.Common.Application.Exceptions;
using HospitalMgt.Application.Common.Abstraction;
using HospitalMgt.Application.Features.Hospitals.ViewModel;
using HospitalMgt.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalMgt.Application.Features.Hospitals.Query
{
    public class GetHospitalCommand : IRequest<HospitalViewModel>
    {
        public Guid guid { get; set; }
    }

    public class GetHospitalHandler : IRequestHandler<GetHospitalCommand, HospitalViewModel>
    {
        private readonly IMapper mapper;
        private readonly IApplicationDbContext dbContext;

        public GetHospitalHandler(IMapper mapper, IApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }
        public async Task<HospitalViewModel> Handle(GetHospitalCommand request, CancellationToken cancellationToken)
        {
            var hospital = await dbContext.Hospitals.Include(x => x.HospitalBranches).AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(x => x.Id == request.guid);
            if (hospital == null) throw new NotFoundException(nameof(Hospital), request.guid);
            return new HospitalViewModel(hospital);
        }
    }
}
