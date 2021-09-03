using EHR.SAS.Common.Application.Exceptions;
using HospitalMgt.Domain.Entities;
using HospitalMgt.Domain.ValueObjects;

namespace HospitalMgt.Application.Features.Hospitals.ViewModel
{
    public class BranchViewModel
    {
        public string BranchName { get; set; }
        public bool IsMainBranch { get; set; }
        public Address Address { get; set; }

        public BranchViewModel(Branches branches)
        {
            if (branches == null) throw new NotFoundException(nameof(Branches));
            BranchName = branches.BranchName;
            IsMainBranch = branches.IsMainBranch;
            Address = branches.Address;
        }
    }
}
