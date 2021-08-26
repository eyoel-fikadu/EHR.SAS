using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.SAS.Common.Application.Abstraction
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}
