using EHR.SAS.Common.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Practitioner.Application.Common.Abstraction;
using Practitioner.Domain.Entities;
using Practitioner.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Practitioner.Application.CQRS.Commands.DoctorInsights
{
    public class AddDoctorInsightCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Insight { get; set; }
    }

    public class AddDoctorInsightCommandHandler : IRequestHandler<AddDoctorInsightCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<AddDoctorInsightCommandHandler> _logger;

        public AddDoctorInsightCommandHandler(IApplicationDbContext context, ILogger<AddDoctorInsightCommandHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(AddDoctorInsightCommand request, CancellationToken cancellationToken)
        {
            var insight = await _context.DoctorInsight.FirstOrDefaultAsync
                (x => x.Id == request.Id);

            if (insight == null) throw new NotFoundException(nameof(DoctorInsight), request.Id);
            insight.Insights.Add(new Insights() { Insight = request.Insight });

            _context.DoctorInsight.Update(insight);

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
