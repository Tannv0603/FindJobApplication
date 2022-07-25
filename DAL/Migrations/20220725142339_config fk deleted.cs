using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class configfkdeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_User",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employer_User",
                table: "Employer");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_User",
                table: "Employee",
                column: "EmployeeID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employer_User",
                table: "Employer",
                column: "EmployerID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_User",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employer_User",
                table: "Employer");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_User",
                table: "Employee",
                column: "EmployeeID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employer_User",
                table: "Employer",
                column: "EmployerID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
