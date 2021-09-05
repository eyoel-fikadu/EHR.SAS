using HospitalMgt.Domain.Entities;
using HospitalMgt.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalMgt.Application.Features.Hospitals.ViewModel
{
    public class HospitalViewModel
    {
        public Guid guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Type { get; set; } //Publicly owned , Non profit, For profit 
        public string Classification { get; set; }
        public List<ContactInformation> contactInformation { get; set; }
        public List<BranchViewModel> Branches  { get; set; }
        public HospitalViewModel(Hospital hospital)
        {
            if (hospital != null)
            {
                guid = hospital.Id;
                Name = hospital.Name;
                Description = hospital.Description;
                Website = hospital.Website;
                Type = hospital.Type.ToString();
                Classification = hospital.Classification.ToString();
                contactInformation = hospital.HospitalContactInformation?.ToList();
                Branches = new List<BranchViewModel>();
                hospital.HospitalBranches?.ToList().ForEach(x =>
                {
                    Branches.Add(new BranchViewModel(x));
                });
            }
        }
    }
}
