using Microsoft.EntityFrameworkCore;
using SuperFormulaRestAPI.Data.Entities;

namespace SuperFormulaRestAPI.Data
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options){}
        public DbSet<Member> Members { get; set; }
        public DbSet<Policy> Policies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            var guid3 = Guid.NewGuid();
            modelBuilder.Entity<Policy>().HasOne(p => p.Member).WithMany(m => m.Policies).HasForeignKey(p => p.MemberId);
            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    MemberId = guid1,
                    FirstName = "Jon",
                    LastName = "Jones",
                    DriverLicenseNumber = "DL1000001",
                    Address = "300 S Rankin St, Richmond, VA, 23224",                   
                },
                new Member
                {
                    MemberId = guid2,
                    FirstName = "Peter",
                    LastName = "Parker",
                    DriverLicenseNumber = "DL1000002",
                    Address = "300 S Rankin St, Richmond, VA, 23224"
                },
                new Member
                {
                    MemberId = guid3,
                    FirstName = "Tony",
                    LastName = "Stark",
                    DriverLicenseNumber = "DL1000003",
                    Address = "300 S Rankin St, Richmond, VA, 23224"
                }
                );
            modelBuilder.Entity<Policy>().HasData(
                new Policy
                {
                    PolicyId = Guid.NewGuid(),
                    VehicleManufacturer = "Toyota",
                    VehicleModel = "Camry",
                    VehicleYear = 1978,
                    VehicleName = "My Car",
                    MemberId = guid1,
                    Premium = 80.95,
                    CreateDate = DateTime.Now,
                    EffectiveDate = DateTime.Now.AddDays(30),
                    ExpirationDate = DateTime.Now.AddMonths(6)
                },
                new Policy
                {
                    PolicyId = Guid.NewGuid(),
                    VehicleManufacturer = "Honda",
                    VehicleModel = "Civic",
                    VehicleYear = 1970,
                    VehicleName = "My Car1",
                    MemberId = guid2,
                    Premium = 80.95,
                    CreateDate = DateTime.Now,
                    EffectiveDate = DateTime.Now.AddDays(30),
                    ExpirationDate = DateTime.Now.AddMonths(6)
                },
                new Policy
                {
                    PolicyId = Guid.NewGuid(),
                    VehicleManufacturer = "Ford",
                    VehicleModel = "Mustang",
                    VehicleYear = 1972,
                    VehicleName = "My Car2",
                    MemberId = guid2,
                    Premium = 80.95,
                    CreateDate = DateTime.Now,
                    EffectiveDate = DateTime.Now.AddDays(30),
                    ExpirationDate = DateTime.Now.AddMonths(6)
                },
                new Policy
                {
                    PolicyId = Guid.NewGuid(),
                    VehicleManufacturer = "Toyota",
                    VehicleModel = "Corolla",
                    VehicleYear = 1966,
                    VehicleName = "My Car",
                    MemberId = guid3,
                    Premium = 80.95,
                    CreateDate = DateTime.Now,
                    EffectiveDate = DateTime.Now.AddDays(30),
                    ExpirationDate = DateTime.Now.AddMonths(6)
                },
                new Policy
                {
                    PolicyId = Guid.NewGuid(),
                    VehicleManufacturer = "Ford",
                    VehicleModel = "Focus",
                    VehicleYear = 1955,
                    VehicleName = "My Car",
                    MemberId = guid3,
                    Premium = 80.95,
                    CreateDate = DateTime.Now,
                    EffectiveDate = DateTime.Now.AddDays(30),
                    ExpirationDate = DateTime.Now.AddMonths(6)
                },
                new Policy
                {
                    PolicyId = Guid.NewGuid(),
                    VehicleManufacturer = "Chevy",
                    VehicleModel = "Impala",
                    VehicleYear = 1976,
                    VehicleName = "My Car",
                    MemberId = guid3,
                    Premium = 80.95,
                    CreateDate = DateTime.Now,
                    EffectiveDate = DateTime.Now.AddDays(30),
                    ExpirationDate = DateTime.Now.AddMonths(6)
                }
                );
        }
    }
}
