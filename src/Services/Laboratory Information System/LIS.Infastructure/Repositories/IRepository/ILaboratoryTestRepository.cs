using LIS.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Infastructure.Repositories.IRepository
{
    public interface ILaboratoryTestRepository
    {
        Task<IEnumerable<LaboratoryTest>> GetLaboratoryTests();
        Task<LaboratoryTest> GetLaboratoryTestById(string id);
        Task<IEnumerable<LaboratoryTest>> GetLaboratoryTestsByTestType(string type);

        Task CreateLaboratoryTest(LaboratoryTest test);
        Task<bool> UpdateLaboratoryTest(LaboratoryTest test);
        Task<bool> DeleteLaboratoryTest(LaboratoryTest test);

    }
}
