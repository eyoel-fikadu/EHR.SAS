using LIS.Infastructure.Entities;
using MongoDB.Driver;

namespace LIS.Infastructure.Data
{
    public interface ILaboratoryContext
    {
        IMongoCollection<LaboratoryTest> LaboratoryTest { get; }
        IMongoCollection<LaboratoryPossibleResults> LaboratoryPossibleResults { get; }
    }
}
