using Microsoft.EntityFrameworkCore;
using SuperFormulaRestAPI.Data.Entities;

using SuperFormulaRestAPI.Models;

namespace SuperFormulaRestAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options){}
        public DbSet<Member> Members { get; set; }
        public DbSet<Policy> Policies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var guid1 = new Guid("F315C0C2-F500-4C4B-BAC0-F8A333F1257F");
            var guid2 = new Guid("823546F0-0E44-472A-B307-419EF2AE6968");
            var guid3 = new Guid("C2576EE3-F0CB-45A4-815F-8199AF25BD72");
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
                    Address = "600 W Blazor St, Hanover, VA, 23225"
                },
                new Member
                {
                    MemberId = guid3,
                    FirstName = "Tony",
                    LastName = "Stark",
                    DriverLicenseNumber = "DL1000003",
                    Address = "400 E 35th St, New York, NY, 11232"
                }
                );
            modelBuilder.Entity<Policy>().HasData(
                new Policy
                {
                    PolicyId = new Guid("45E1658F-7530-4AFB-A10D-62862ED124DF"),
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
                    PolicyId = new Guid("0F045C1A-244D-4666-86E9-5B1BA088A771"),
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
                    PolicyId = new Guid("97471354-5D3C-4666-98F4-448E238D606F"),
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
                    PolicyId = new Guid("A533D47B-41DC-43D6-9834-EC0C2E3C39D7"),
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
                    PolicyId = new Guid("850E38FC-404C-4767-BB08-ACDEF824E3C8"),
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
                    PolicyId = new Guid("54215567-7C33-4537-A665-9E28456DC728"),
                    VehicleManufacturer = "Chevy",
                    VehicleModel = "Impala",
                    VehicleYear = 1976,
                    VehicleName = "My Car",
                    MemberId = guid3,
                    Premium = 80.95,
                    CreateDate = DateTime.Parse("2022-03-24"),
                    EffectiveDate = DateTime.Parse("2022-04-24"),
                    ExpirationDate = DateTime.Parse("2022-5-24")
                }
                );
        }
    }
}
