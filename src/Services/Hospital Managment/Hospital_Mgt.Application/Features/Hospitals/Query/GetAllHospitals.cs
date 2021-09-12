using HospitalMgt.Application.Common.Abstraction;
using HospitalMgt.Application.Common.Mapping;
using HospitalMgt.Application.Features.Hospitals.ViewModel;
using HospitalMgt.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalMgt.Application.Features.Hospitals.Query
{
    public class GetAllHospitalsCommand : PaginatedRequest, IRequest<PaginatedList<HospitalViewModel>>
    {

    }

    public class GetAllHospitalsHandler : IRequestHandler<GetAllHospitalsCommand, PaginatedList<HospitalViewModel>>
    {
        private readonly IApplicationDbContext dbContext;

        public GetAllHospitalsHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<PaginatedList<HospitalViewModel>> Handle(GetAllHospitalsCommand request, CancellationToken cancellationToken)
        {
            var hospitals = await dbContext.Hospitals.Include(x => x.HospitalBranches).AsNoTrackingWithIdentityResolution().PaginatedListAsync(request);
            var list = hospitals?.Items?.Select(c => new HospitalViewModel(c)).ToList();
            if (list == null) return new PaginatedList<HospitalViewModel>(new List<HospitalViewModel>(), 0, 0, 0);
            return new PaginatedList<HospitalViewModel>(list, hospitals.TotalCount, hospitals.PageIndex, request.PageSize);
        }
    }
}
