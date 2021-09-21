using EHR.SAS.Common.Application.Abstraction;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Practitioner.Query.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);

        public Guid UserGuidId => GetUserId();

        public Guid GetUserId()
        {
            var id = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null) return Guid.Empty;
            try
            {
                return Guid.Parse(id);
            }
            catch
            {
                return Guid.Empty;
            }
        }
    }
}
