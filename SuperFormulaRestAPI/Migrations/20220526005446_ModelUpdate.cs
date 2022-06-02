using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperFormulaRestAPI.Migrations
{
    public partial class ModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("0a662ea9-e0e2-4fdf-9157-bc1aca27b588"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("3508732f-f3e5-48f5-8431-90e56fab44a1"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("768ffdeb-42ed-4c24-ad68-2f0102e02360"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("869f0281-68bc-4c8a-861e-eab060a10ad7"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("b2ff9388-8f8e-49dc-8d1d-4f9cca557b00"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("c621403e-4c2a-4d31-a282-3970968d5f98"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("07e795a2-4df9-4885-80c6-a1a4ada01483"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("25210260-a4fe-4a54-80c5-33073c9122e0"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("76da447e-227f-4507-a66e-b881178cf254"));

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "EffectiveDate",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Premium",
                table: "Members");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Policies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EffectiveDate",
                table: "Policies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Policies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Premium",
                table: "Policies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Address", "DriverLicenseNumber", "FirstName", "LastName" },
                values: new object[] { new Guid("823546f0-0e44-472a-b307-419ef2ae6968"), "300 S Rankin St, Richmond, VA, 23224", "DL1000002", "Peter", "Parker" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Address", "DriverLicenseNumber", "FirstName", "LastName" },
                values: new object[] { new Guid("c2576ee3-f0cb-45a4-815f-8199af25bd72"), "300 S Rankin St, Richmond, VA, 23224", "DL1000003", "Tony", "Stark" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Address", "DriverLicenseNumber", "FirstName", "LastName" },
                values: new object[] { new Guid("f315c0c2-f500-4c4b-bac0-f8a333f1257f"), "300 S Rankin St, Richmond, VA, 23224", "DL1000001", "Jon", "Jones" });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "PolicyId", "CreateDate", "EffectiveDate", "ExpirationDate", "MemberId", "Premium", "VehicleManufacturer", "VehicleModel", "VehicleName", "VehicleYear" },
                values: new object[,]
                {
                    { new Guid("0f045c1a-244d-4666-86e9-5b1ba088a771"), new DateTime(2022, 5, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4813), new DateTime(2022, 6, 24, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4814), new DateTime(2022, 11, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4816), new Guid("823546f0-0e44-472a-b307-419ef2ae6968"), 80.950000000000003, "Ford", "Mustang", "My Car2", 1972 },
                    { new Guid("45e1658f-7530-4afb-a10d-62862ed124df"), new DateTime(2022, 5, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4771), new DateTime(2022, 6, 24, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4801), new DateTime(2022, 11, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4803), new Guid("f315c0c2-f500-4c4b-bac0-f8a333f1257f"), 80.950000000000003, "Toyota", "Camry", "My Car", 1978 },
                    { new Guid("54215567-7c33-4537-a665-9e28456dc728"), new DateTime(2022, 5, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4819), new DateTime(2022, 6, 24, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4820), new DateTime(2022, 11, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4821), new Guid("c2576ee3-f0cb-45a4-815f-8199af25bd72"), 80.950000000000003, "Toyota", "Corolla", "My Car", 1966 },
                    { new Guid("850e38fc-404c-4767-bb08-acdef824e3c8"), new DateTime(2022, 5, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4844), new DateTime(2022, 6, 24, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4845), new DateTime(2022, 11, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4846), new Guid("c2576ee3-f0cb-45a4-815f-8199af25bd72"), 80.950000000000003, "Chevy", "Impala", "My Car", 1976 },
                    { new Guid("97471354-5d3c-4666-98f4-448e238d606f"), new DateTime(2022, 5, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4807), new DateTime(2022, 6, 24, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4809), new DateTime(2022, 11, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4810), new Guid("823546f0-0e44-472a-b307-419ef2ae6968"), 80.950000000000003, "Honda", "Civic", "My Car1", 1970 },
                    { new Guid("a533d47b-41dc-43d6-9834-ec0c2e3c39d7"), new DateTime(2022, 5, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4838), new DateTime(2022, 6, 24, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4839), new DateTime(2022, 11, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4841), new Guid("c2576ee3-f0cb-45a4-815f-8199af25bd72"), 80.950000000000003, "Ford", "Focus", "My Car", 1955 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("0f045c1a-244d-4666-86e9-5b1ba088a771"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("45e1658f-7530-4afb-a10d-62862ed124df"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("54215567-7c33-4537-a665-9e28456dc728"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("850e38fc-404c-4767-bb08-acdef824e3c8"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("97471354-5d3c-4666-98f4-448e238d606f"));

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("a533d47b-41dc-43d6-9834-ec0c2e3c39d7"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("823546f0-0e44-472a-b307-419ef2ae6968"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("c2576ee3-f0cb-45a4-815f-8199af25bd72"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("f315c0c2-f500-4c4b-bac0-f8a333f1257f"));

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "EffectiveDate",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "Premium",
                table: "Policies");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EffectiveDate",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Premium",
                table: "Members",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
        }
    }
}
