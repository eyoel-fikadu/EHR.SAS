using LIS.Infastructure.Entities;
using LIS.Infastructure.Seed;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Infastructure.Data
{
    public class LaboratoryContext : ILaboratoryContext
    {
        public LaboratoryContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("MongoDbConnection:ConnectionStrings"));
            var database = client.GetDatabase(configuration.GetValue<string>("MongoDbConnection:DatbaseName"));
            LaboratoryTest = database.GetCollection<LaboratoryTest>(configuration.GetValue<string>("MongoDbConnection:LaboratoryTest"));
            LaboratoryPossibleResults = database.GetCollection<LaboratoryPossibleResults>(configuration.GetValue<string>("MongoDbConnection:LaboratoryPossibleResults"));

            //LaboratoryContextSeed.SeedData(LaboratoryTest);
        }
        public IMongoCollection<LaboratoryTest> LaboratoryTest { get; }

        public IMongoCollection<LaboratoryPossibleResults> LaboratoryPossibleResults { get; }
    }
}
