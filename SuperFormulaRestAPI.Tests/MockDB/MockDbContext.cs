using Microsoft.EntityFrameworkCore;
using SuperFormulaRestAPI.Data;
using SuperFormulaRestAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperFormulaRestAPIUnitTests.MockDB
{
    public class MockDbContext
    {
        public static async Task<DatabaseContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
            var databaseContext = new DatabaseContext(options);
            await databaseContext.Database.EnsureCreatedAsync();

            return databaseContext;

        }
    }
}
