using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class updatekey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeAppliedForJob_JobID",
                table: "EmployeeAppliedForJob");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeAppliedForJob",
                table: "EmployeeAppliedForJob",
                columns: new[] { "JobID", "CVID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeAppliedForJob",
                table: "EmployeeAppliedForJob");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAppliedForJob_JobID",
                table: "EmployeeAppliedForJob",
                column: "JobID");
        }
    }
}
