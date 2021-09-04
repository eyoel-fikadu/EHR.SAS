using EHR.SAS.Common.Application.Exceptions;
using HospitalMgt.Application.Common.Abstraction;
using HospitalMgt.Domain.Entities;
using HospitalMgt.Domain.ValueObjects;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalMgt.Application.Features.Hospitals.Command
{
    public class AddHospitalBranchCommand : IRequest<Guid>, IRegister
    {
        public Guid hospitalGuid { get; set; }
        public string BranchName { get; set; }
        public bool IsMainBranch { get; set; }
        public Address Address { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddHospitalBranchCommand, Branches>().PreserveReference(true);
            //config.NewConfig<ICollection<AddHospitalBranchCommand>, ICollection<Branches>>().PreserveReference(true);
        }
    }

    public class AddHospitalBranchHanlder : IRequestHandler<AddHospitalBranchCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IApplicationDbContext dbContext;

        public AddHospitalBranchHanlder(IMapper mapper, IApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }
        public async Task<Guid> Handle(AddHospitalBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = mapper.Map<Branches>(request);
            var hospital = await dbContext.Hospitals.Include(x => x.HospitalBranches).FirstOrDefaultAsync(x => x.Id == request.hospitalGuid);
            if (hospital == null) throw new NotFoundException(nameof(Hospital), request.hospitalGuid);
            hospital.HospitalBranches.Add(branch);

            await dbContext.SaveChangesAsync(cancellationToken);

            return branch.Id;
        }
    }
}
