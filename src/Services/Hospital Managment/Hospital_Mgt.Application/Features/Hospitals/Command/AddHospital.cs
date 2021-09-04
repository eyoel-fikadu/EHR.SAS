using HospitalMgt.Application.Common.Abstraction;
using HospitalMgt.Domain.Entities;
using HospitalMgt.Domain.ValueObjects;
using Mapster;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalMgt.Application.Features.Hospitals.Command
{
    public class AddHospitalCommand : IRequest<Guid>, IRegister
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Type { get; set; } //Publicly owned , Non profit, For profit 
        public string TypeOfCare { get; set; }
        public ICollection<AddHospitalBranchCommand> HospitalBranches { get; set; }
        public ICollection<ContactInformation> HospitalContactInformation { get; set; }
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddHospitalCommand, Hospital>();
        }
    }

    public class AddHospitalHandler : IRequestHandler<AddHospitalCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IApplicationDbContext dbContext;

        public AddHospitalHandler(IMapper mapper, IApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task<Guid> Handle(AddHospitalCommand request, CancellationToken cancellationToken)
        {
            var newHospital = mapper.Map<Hospital>(request);
            dbContext.Hospitals.Add(newHospital);
            await dbContext.SaveChangesAsync(cancellationToken);
            return newHospital.Id;
        }
    }
}
