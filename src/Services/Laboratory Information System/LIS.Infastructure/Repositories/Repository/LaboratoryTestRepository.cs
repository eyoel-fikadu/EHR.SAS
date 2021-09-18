using LIS.Infastructure.Data;
using LIS.Infastructure.Entities;
using LIS.Infastructure.Repositories.IRepository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Infastructure.Repositories.Repository
{
    public class LaboratoryTestRepository : ILaboratoryTestRepository
    {
        private readonly ILaboratoryContext _context;

        public LaboratoryTestRepository(ILaboratoryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateLaboratoryTest(LaboratoryTest test)
        {
            await _context.LaboratoryTest.InsertOneAsync(test);
        }

        public async Task<bool> DeleteLaboratoryTest(LaboratoryTest test)
        {
            FilterDefinition<LaboratoryTest> filters = Builders<LaboratoryTest>.Filter.Eq(p => p.Id, test.Id);

            var result = await _context
                                   .LaboratoryTest
                                   .DeleteOneAsync(filters);

            return result.IsAcknowledged;
        }

        public async Task<LaboratoryTest> GetLaboratoryTestById(string id)
        {
            return await _context
                            .LaboratoryTest
                            .Find(prop => prop.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<LaboratoryTest>> GetLaboratoryTests()
        {
            return await _context
                            .LaboratoryTest
                            .Find(prop => true)
                            .ToListAsync();
        }

        public async Task<IEnumerable<LaboratoryTest>> GetLaboratoryTestsByTestType(string type)
        {
            FilterDefinition<LaboratoryTest> filters = Builders<LaboratoryTest>.Filter.Eq(p => p.TestType, type);
            return await _context
                            .LaboratoryTest
                            .Find(filters)
                            .ToListAsync();
        }

        public async Task<bool> UpdateLaboratoryTest(LaboratoryTest test)
        {
            var result = await _context
                                    .LaboratoryTest
                                    .ReplaceOneAsync(filter: g => g.Id == test.Id, replacement: test);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
