using EHR.SAS.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Domain.Entities
{
    public abstract class PractitionerAuditableEntity : AuditableEntity
    {
        public Guid Id { get; set; }
    }
}
