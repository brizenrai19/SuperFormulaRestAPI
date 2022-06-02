using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperFormulaRestAPI.Migrations
{
    public partial class InitalCreateInAzure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("823546f0-0e44-472a-b307-419ef2ae6968"),
                column: "Address",
                value: "600 W Blazor St, Hanover, VA, 23225");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("c2576ee3-f0cb-45a4-815f-8199af25bd72"),
                column: "Address",
                value: "400 E 35th St, New York, NY, 11232");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("0f045c1a-244d-4666-86e9-5b1ba088a771"),
                columns: new[] { "CreateDate", "EffectiveDate", "ExpirationDate", "VehicleManufacturer", "VehicleModel", "VehicleName", "VehicleYear" },
                values: new object[] { new DateTime(2022, 6, 1, 23, 44, 36, 558, DateTimeKind.Local).AddTicks(815), new DateTime(2022, 7, 1, 23, 44, 36, 558, DateTimeKind.Local).AddTicks(817), new DateTime(2022, 12, 1, 23, 44, 36, 558, DateTimeKind.Local).AddTicks(818), "Honda", "Civic", "My Car1", 1970 });

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("45e1658f-7530-4afb-a10d-62862ed124df"),
                columns: new[] { "CreateDate", "EffectiveDate", "ExpirationDate" },
                values: new object[] { new DateTime(2022, 6, 1, 23, 44, 36, 558, DateTimeKind.Local).AddTicks(780), new DateTime(2022, 7, 1, 23, 44, 36, 558, DateTimeKind.Local).AddTicks(809), new DateTime(2022, 12, 1, 23, 44, 36, 558, DateTimeKind.Local).AddTicks(810) });

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("54215567-7c33-4537-a665-9e28456dc728"),
                columns: new[] { "CreateDate", "EffectiveDate", "ExpirationDate", "VehicleManufacturer", "VehicleModel", "VehicleYear" },
                values: new object[] { new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chevy", "Impala", 1976 });

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("850e38fc-404c-4767-bb08-acdef824e3c8"),
                columns: new[] { "CreateDate", "EffectiveDate", "ExpirationDate", "VehicleManufacturer", "VehicleModel", "VehicleYear" },
                values: new object[] { new DateTime(2022, 6, 1, 23, 44, 36, 558, DateTimeKind.Local).AddTicks(833), new DateTime(2022, 7, 1, 23, 44, 36, 558, DateTimeKind.Local).AddTicks(835), new DateTime(2022, 12, 1, 23, 44, 36, 558, DateTimeKind.Local).AddTicks(836), "Ford", "Focus", 1955 });

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("97471354-5d3c-4666-98f4-448e238d606f"),
                columns: new[] { "CreateDate", "EffectiveDate", "ExpirationDate", "VehicleManufacturer", "VehicleModel", "VehicleName", "VehicleYear" },
                values: new object[] { new DateTime(2022, 6, 1, 23, 44, 36, 558, DateTimeKind.Local).AddTicks(822), new DateTime(2022, 7, 1, 23, 44, 36, 558, DateTimeKind.Local).AddTicks(824), new DateTime(2022, 12, 1, 23, 44, 36, 558, DateTimeKind.Local).AddTicks(825), "Ford", "Mustang", "My Car2", 1972 });

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("a533d47b-41dc-43d6-9834-ec0c2e3c39d7"),
                columns: new[] { "CreateDate", "EffectiveDate", "ExpirationDate", "VehicleManufacturer", "VehicleModel", "VehicleYear" },
                values: new object[] { new DateTime(2022, 6, 1, 23, 44, 36, 558, DateTimeKind.Local).AddTicks(828), new DateTime(2022, 7, 1, 23, 44, 36, 558, DateTimeKind.Local).AddTicks(829), new DateTime(2022, 12, 1, 23, 44, 36, 558, DateTimeKind.Local).AddTicks(831), "Toyota", "Corolla", 1966 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("823546f0-0e44-472a-b307-419ef2ae6968"),
                column: "Address",
                value: "300 S Rankin St, Richmond, VA, 23224");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("c2576ee3-f0cb-45a4-815f-8199af25bd72"),
                column: "Address",
                value: "300 S Rankin St, Richmond, VA, 23224");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("0f045c1a-244d-4666-86e9-5b1ba088a771"),
                columns: new[] { "CreateDate", "EffectiveDate", "ExpirationDate", "VehicleManufacturer", "VehicleModel", "VehicleName", "VehicleYear" },
                values: new object[] { new DateTime(2022, 5, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4813), new DateTime(2022, 6, 24, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4814), new DateTime(2022, 11, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4816), "Ford", "Mustang", "My Car2", 1972 });

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("45e1658f-7530-4afb-a10d-62862ed124df"),
                columns: new[] { "CreateDate", "EffectiveDate", "ExpirationDate" },
                values: new object[] { new DateTime(2022, 5, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4771), new DateTime(2022, 6, 24, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4801), new DateTime(2022, 11, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4803) });

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("54215567-7c33-4537-a665-9e28456dc728"),
                columns: new[] { "CreateDate", "EffectiveDate", "ExpirationDate", "VehicleManufacturer", "VehicleModel", "VehicleYear" },
                values: new object[] { new DateTime(2022, 5, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4819), new DateTime(2022, 6, 24, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4820), new DateTime(2022, 11, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4821), "Toyota", "Corolla", 1966 });

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("850e38fc-404c-4767-bb08-acdef824e3c8"),
                columns: new[] { "CreateDate", "EffectiveDate", "ExpirationDate", "VehicleManufacturer", "VehicleModel", "VehicleYear" },
                values: new object[] { new DateTime(2022, 5, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4844), new DateTime(2022, 6, 24, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4845), new DateTime(2022, 11, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4846), "Chevy", "Impala", 1976 });

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("97471354-5d3c-4666-98f4-448e238d606f"),
                columns: new[] { "CreateDate", "EffectiveDate", "ExpirationDate", "VehicleManufacturer", "VehicleModel", "VehicleName", "VehicleYear" },
                values: new object[] { new DateTime(2022, 5, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4807), new DateTime(2022, 6, 24, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4809), new DateTime(2022, 11, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4810), "Honda", "Civic", "My Car1", 1970 });

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: new Guid("a533d47b-41dc-43d6-9834-ec0c2e3c39d7"),
                columns: new[] { "CreateDate", "EffectiveDate", "ExpirationDate", "VehicleManufacturer", "VehicleModel", "VehicleYear" },
                values: new object[] { new DateTime(2022, 5, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4838), new DateTime(2022, 6, 24, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4839), new DateTime(2022, 11, 25, 20, 54, 45, 977, DateTimeKind.Local).AddTicks(4841), "Ford", "Focus", 1955 });
        }
    }
}
