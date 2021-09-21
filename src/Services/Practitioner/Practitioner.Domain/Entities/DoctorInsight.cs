using Practitioner.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Practitioner.Domain.Entities
{
    public class DoctorInsight : PractitionerAuditableEntity
    {
        public Guid CardId { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public List<Insights> Insights { get; set; } = new List<Insights>();
    }
}
