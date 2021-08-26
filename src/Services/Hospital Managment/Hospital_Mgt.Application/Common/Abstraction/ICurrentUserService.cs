using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMgt.Application.Common.Abstraction
{
    public interface ICurrentUserService
    {
        Guid UserGuidId { get; }
    }
}
