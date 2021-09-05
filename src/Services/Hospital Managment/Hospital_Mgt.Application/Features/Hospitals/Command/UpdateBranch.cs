using EHR.SAS.Common.Application.Exceptions;
using FluentValidation;
using HospitalMgt.Application.Common.Abstraction;
using HospitalMgt.Domain.Entities;
using HospitalMgt.Domain.ValueObjects;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalMgt.Application.Features.Hospitals.Command
{
    public class UpdateBranchCommand : IRequest<bool>
    {
        public Guid id { get; set; }
        public string BranchName { get; set; }
        public bool IsMainBranch { get; set; }
        public Address Address { get; set; }
    }

    public class UpdateBranchHandler : IRequestHandler<UpdateBranchCommand, bool>
    {
        private readonly IApplicationDbContext dbContext;

        public UpdateBranchHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await dbContext.HospitalBranches.FindAsync(request.id);
            if (branch == null) throw new NotFoundException(nameof(Branches), request.id);
            
            branch.BranchName = request.BranchName;
            branch.IsMainBranch = request.IsMainBranch;
            branch.Address = request.Address;

            return true;
        }
    }

    public class UpdateBranchValidator : AbstractValidator<UpdateBranchCommand>
    {
        public UpdateBranchValidator()
        {
            RuleFor(x => x.id).NotNull();
        }
    }
}
