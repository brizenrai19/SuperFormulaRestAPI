using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperFormulaRestAPI.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Premium = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleYear = table.Column<int>(type: "int", nullable: false),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleManufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.PolicyId);
                    table.ForeignKey(
                        name: "FK_Policies_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Address", "CreateDate", "DriverLicenseNumber", "EffectiveDate", "ExpirationDate", "FirstName", "LastName", "Premium" },
                values: new object[] { new Guid("07e795a2-4df9-4885-80c6-a1a4ada01483"), "300 S Rankin St, Richmond, VA, 23224", new DateTime(2022, 5, 25, 20, 20, 47, 869, DateTimeKind.Local).AddTicks(2026), "DL1000003", new DateTime(2022, 6, 24, 20, 20, 47, 869, DateTimeKind.Local).AddTicks(2027), new DateTime(2022, 11, 25, 20, 20, 47, 869, DateTimeKind.Local).AddTicks(2028), "Tony", "Stark", 80.950000000000003 });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Address", "CreateDate", "DriverLicenseNumber", "EffectiveDate", "ExpirationDate", "FirstName", "LastName", "Premium" },
                values: new object[] { new Guid("25210260-a4fe-4a54-80c5-33073c9122e0"), "300 S Rankin St, Richmond, VA, 23224", new DateTime(2022, 5, 25, 20, 20, 47, 869, DateTimeKind.Local).AddTicks(1987), "DL1000001", new DateTime(2022, 6, 24, 20, 20, 47, 869, DateTimeKind.Local).AddTicks(2015), new DateTime(2022, 11, 25, 20, 20, 47, 869, DateTimeKind.Local).AddTicks(2016), "Jon", "Jones", 80.950000000000003 });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Address", "CreateDate", "DriverLicenseNumber", "EffectiveDate", "ExpirationDate", "FirstName", "LastName", "Premium" },
                values: new object[] { new Guid("76da447e-227f-4507-a66e-b881178cf254"), "300 S Rankin St, Richmond, VA, 23224", new DateTime(2022, 5, 25, 20, 20, 47, 869, DateTimeKind.Local).AddTicks(2020), "DL1000002", new DateTime(2022, 6, 24, 20, 20, 47, 869, DateTimeKind.Local).AddTicks(2021), new DateTime(2022, 11, 25, 20, 20, 47, 869, DateTimeKind.Local).AddTicks(2023), "Peter", "Parker", 80.950000000000003 });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "PolicyId", "MemberId", "VehicleManufacturer", "VehicleModel", "VehicleName", "VehicleYear" },
                values: new object[,]
                {
                    { new Guid("0a662ea9-e0e2-4fdf-9157-bc1aca27b588"), new Guid("76da447e-227f-4507-a66e-b881178cf254"), "Honda", "Civic", "My Car1", 1970 },
                    { new Guid("3508732f-f3e5-48f5-8431-90e56fab44a1"), new Guid("07e795a2-4df9-4885-80c6-a1a4ada01483"), "Ford", "Focus", "My Car", 1955 },
                    { new Guid("768ffdeb-42ed-4c24-ad68-2f0102e02360"), new Guid("07e795a2-4df9-4885-80c6-a1a4ada01483"), "Chevy", "Impala", "My Car", 1976 },
                    { new Guid("869f0281-68bc-4c8a-861e-eab060a10ad7"), new Guid("76da447e-227f-4507-a66e-b881178cf254"), "Ford", "Mustang", "My Car2", 1972 },
                    { new Guid("b2ff9388-8f8e-49dc-8d1d-4f9cca557b00"), new Guid("25210260-a4fe-4a54-80c5-33073c9122e0"), "Toyota", "Camry", "My Car", 1978 },
                    { new Guid("c621403e-4c2a-4d31-a282-3970968d5f98"), new Guid("07e795a2-4df9-4885-80c6-a1a4ada01483"), "Toyota", "Corolla", "My Car", 1966 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Policies_MemberId",
                table: "Policies",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
