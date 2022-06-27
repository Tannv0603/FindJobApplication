using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class configdatetimeandcurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "StartSalary",
                table: "Job",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Job",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<decimal>(
                name: "EndSalary",
                table: "Job",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Job",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "StartSalary",
                table: "Job",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Job",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<decimal>(
                name: "EndSalary",
                table: "Job",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Job",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
