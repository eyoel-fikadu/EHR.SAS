using MediatR;
using Microsoft.Extensions.Logging;
using Practitioner.Application.Common.Abstraction;
using Practitioner.Domain.Entities;
using Practitioner.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practitioner.Application.CQRS.Commands.DoctorInsights
{
    public class CreateDoctorInsightCommand : IRequest<Guid>
    {
        public Guid CardId { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public List<string> Insights { get; set; } = new List<string>();
    }

    public class CreateDoctorInsightCommandHandler : IRequestHandler<CreateDoctorInsightCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<CreateDoctorInsightCommand> _logger;

        public CreateDoctorInsightCommandHandler(IApplicationDbContext context, ILogger<CreateDoctorInsightCommand> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Guid> Handle(CreateDoctorInsightCommand request, CancellationToken cancellationToken)
        {
            var doctorInsight = new DoctorInsight()
            {
                CardId = request.CardId,
                DoctorId = request.DoctorId,
                PatientId = request.PatientId
            };

            request.Insights?.ForEach(x =>
                doctorInsight.Insights.Add(new Insights() { Insight = x})   
            );

            _context.DoctorInsight.Add(doctorInsight);

            await _context.SaveChangesAsync(cancellationToken);

            return doctorInsight.Id;
        }
    }
}
