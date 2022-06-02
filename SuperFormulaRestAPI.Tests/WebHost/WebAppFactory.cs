using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuperFormulaRestAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperFormulaRestAPITests.WebHost
{
    public class WebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                        desc => desc.ServiceType == typeof(DbContextOptions<DatabaseContext>)
                    );

                //Remove DatabaseContext registration from program class
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                //Add InMemoryDatabaseContext for testing
                services.AddDbContext<DatabaseContext>(
                    opts =>
                    {
                        opts.UseInMemoryDatabase("TestDB");
                    }
                );

                var serviceProvider = services.BuildServiceProvider();
                using (var scope = serviceProvider.CreateScope())
                {
                    using (var webAppCtx = scope.ServiceProvider.GetRequiredService<DatabaseContext>())
                    {
                        try
                        {
                            webAppCtx.Database.EnsureCreated();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }   
                }
            });

        }
    }
}
