using System;

namespace EHR.SAS.Common.Application.Abstraction
{
    public interface ICurrentUserService
    {
        Guid UserGuidId { get; }
    }
}
