using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class configfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactEmployee_CV",
                table: "ContactEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactEmployee_Employee",
                table: "ContactEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactEmployee_JobTitle",
                table: "ContactEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactEmployee_Skill",
                table: "ContactEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_CV_Employee",
                table: "CV");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_User",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAppliedForJob_CV",
                table: "EmployeeAppliedForJob");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAppliedForJob_Job",
                table: "EmployeeAppliedForJob");

            migrationBuilder.DropForeignKey(
                name: "FK_Employer_User",
                table: "Employer");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_City",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Employer",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_JobTitle",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Skill",
                table: "Job");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactEmployee_CV",
                table: "ContactEmployee",
                column: "CVID",
                principalTable: "CV",
                principalColumn: "CVID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactEmployee_Employee",
                table: "ContactEmployee",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactEmployee_JobTitle",
                table: "ContactEmployee",
                column: "JobTitleID",
                principalTable: "JobTitle",
                principalColumn: "TitleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactEmployee_Skill",
                table: "ContactEmployee",
                column: "JobSkill",
                principalTable: "Skill",
                principalColumn: "SkillID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CV_Employee",
                table: "CV",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_User",
                table: "Employee",
                column: "EmployeeID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Employer_User",
                table: "Employer",
                column: "EmployerID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_City",
                table: "Job",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Employer",
                table: "Job",
                column: "EmployerID",
                principalTable: "Employer",
                principalColumn: "EmployerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_JobTitle",
                table: "Job",
                column: "JobTitleID",
                principalTable: "JobTitle",
                principalColumn: "TitleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Skill",
                table: "Job",
                column: "SkillID",
                principalTable: "Skill",
                principalColumn: "SkillID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactEmployee_CV",
                table: "ContactEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactEmployee_Employee",
                table: "ContactEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactEmployee_JobTitle",
                table: "ContactEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactEmployee_Skill",
                table: "ContactEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_CV_Employee",
                table: "CV");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_User",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAppliedForJob_CV",
                table: "EmployeeAppliedForJob");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAppliedForJob_Job",
                table: "EmployeeAppliedForJob");

            migrationBuilder.DropForeignKey(
                name: "FK_Employer_User",
                table: "Employer");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_City",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Employer",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_JobTitle",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Skill",
                table: "Job");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactEmployee_CV",
                table: "ContactEmployee",
                column: "CVID",
                principalTable: "CV",
                principalColumn: "CVID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactEmployee_Employee",
                table: "ContactEmployee",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactEmployee_JobTitle",
                table: "ContactEmployee",
                column: "JobTitleID",
                principalTable: "JobTitle",
                principalColumn: "TitleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactEmployee_Skill",
                table: "ContactEmployee",
                column: "JobSkill",
                principalTable: "Skill",
                principalColumn: "SkillID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CV_Employee",
                table: "CV",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_User",
                table: "Employee",
                column: "EmployeeID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Employer_User",
                table: "Employer",
                column: "EmployerID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_City",
                table: "Job",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Employer",
                table: "Job",
                column: "EmployerID",
                principalTable: "Employer",
                principalColumn: "EmployerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_JobTitle",
                table: "Job",
                column: "JobTitleID",
                principalTable: "JobTitle",
                principalColumn: "TitleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Skill",
                table: "Job",
                column: "SkillID",
                principalTable: "Skill",
                principalColumn: "SkillID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
