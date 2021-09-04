using HospitalMgt.Application.Common.Abstraction;
using HospitalMgt.Domain.Entities;
using Mapster;
using MapsterMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalMgt.Application.Features.Hospitals.Command
{
    public class UpdateHospitalCommand : IRequest<bool>, IRegister
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Type { get; set; } //Publicly owned , Non profit, For profit 
        public string TypeOfCare { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UpdateHospitalCommand, Hospital>();
        }
    }

    public class UpdateHospitalHandler : IRequestHandler<UpdateHospitalCommand, bool>
    {
        private readonly IMapper mapper;
        private readonly IApplicationDbContext dbContext;

        public UpdateHospitalHandler(IMapper mapper, IApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }
        public async Task<bool> Handle(UpdateHospitalCommand request, CancellationToken cancellationToken)
        {
            var hospital = await dbContext.Hospitals.FindAsync(request.id);
            mapper.Map(request, hospital);
            dbContext.Hospitals.Update(hospital);
            await dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
