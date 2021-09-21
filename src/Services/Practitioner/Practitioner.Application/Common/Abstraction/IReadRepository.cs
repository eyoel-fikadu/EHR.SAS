using Practitioner.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Practitioner.Application.Common.Abstraction
{
    public interface IReadRepository
    {
        Task<DoctorInsight> GetDoctorInsightByCardId(Guid cardId);
    }
}
