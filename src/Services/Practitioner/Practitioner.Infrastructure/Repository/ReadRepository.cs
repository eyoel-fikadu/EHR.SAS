using Dapper;
using EHR.SAS.Common.Application.Exceptions;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Practitioner.Application.Common.Abstraction;
using Practitioner.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Practitioner.Infrastructure.Repository
{
    public class ReadRepository : IReadRepository
    {
        private readonly string ConnectionString;

        public ReadRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("PostgresConnection");
        }

        public async Task<DoctorInsight> GetDoctorInsightByCardId(Guid cardId)
        {
            using var connection = new NpgsqlConnection(ConnectionString);

            var insights = await connection.QueryFirstOrDefaultAsync<DoctorInsight>
                ("SELECT * FROM doctors.DoctorInsight WHERE CardId = @CardId", new { CardId = cardId});

            if (insights == null) throw new NotFoundException(nameof(DoctorInsight), cardId);

            return insights;
        }
    }
}
