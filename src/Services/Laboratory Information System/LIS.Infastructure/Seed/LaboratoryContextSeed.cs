using LIS.Infastructure.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Infastructure.Seed
{
    public class LaboratoryContextSeed
    {
        public static void SeedData(IMongoCollection<LaboratoryTest> laboratoryTestCollection)
        {
            //bool exist = laboratoryTestCollection.Find(p => true).Any();
            //if(!exist)
            //{
            //    await laboratoryTestCollection.InsertManyAsync(GetPreConfiguredTests());
            //}
        }

        private static IEnumerable<LaboratoryTest> GetPreConfiguredTests()
        {
            return new List<LaboratoryTest>() 
            {
                new LaboratoryTest()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    ResultType = "Type 1",
                    TestName = "Test 1",
                    TestType = "Test Type 1"
                },
                new LaboratoryTest()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    ResultType = "Type 2",
                    TestName = "Test 2",
                    TestType = "Test Type 2"
                },
                new LaboratoryTest()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    ResultType = "Type 3",
                    TestName = "Test 3",
                    TestType = "Test Type 3"
                }
            };
        }
    }
}
