using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class deletecascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAppliedForJob_CV",
                table: "EmployeeAppliedForJob");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAppliedForJob_Job",
                table: "EmployeeAppliedForJob");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAppliedForJob_CV",
                table: "EmployeeAppliedForJob",
                column: "CVID",
                principalTable: "CV",
                principalColumn: "CVID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAppliedForJob_Job",
                table: "EmployeeAppliedForJob",
                column: "JobID",
                principalTable: "Job",
                principalColumn: "JobID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAppliedForJob_CV",
                table: "EmployeeAppliedForJob");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAppliedForJob_Job",
                table: "EmployeeAppliedForJob");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAppliedForJob_CV",
                table: "EmployeeAppliedForJob",
                column: "CVID",
                principalTable: "CV",
                principalColumn: "CVID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAppliedForJob_Job",
                table: "EmployeeAppliedForJob",
                column: "JobID",
                principalTable: "Job",
                principalColumn: "JobID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
