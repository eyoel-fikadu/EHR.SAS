using EHR.SAS.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMgt.Domain.Entities
{
    public abstract class HospitalAuditableEntity : AuditableEntity
    {
        public Guid Id { get; protected set; }
    }
}
