﻿// <auto-generated />
using System;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(FindingJobContext))]
    [Migration("20220515060315_init-new")]
    partial class initnew
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CityID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("DAL.Entities.ContactEmployee", b =>
                {
                    b.Property<int>("Cvid")
                        .HasColumnType("int")
                        .HasColumnName("CVID");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("EmployeeID");

                    b.Property<int>("JobSkill")
                        .HasColumnType("int");

                    b.Property<int>("JobTitleId")
                        .HasColumnType("int")
                        .HasColumnName("JobTitleID");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("int");

                    b.HasIndex("Cvid");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("JobSkill");

                    b.HasIndex("JobTitleId");

                    b.ToTable("ContactEmployee");
                });

            modelBuilder.Entity("DAL.Entities.Cv", b =>
                {
                    b.Property<int>("Cvid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CVID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("EmployeeID");

                    b.Property<string>("StoredUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cvid");

                    b.HasIndex("EmployeeId");

                    b.ToTable("CV");
                });

            modelBuilder.Entity("DAL.Entities.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("EmployeeID");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("CityID");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("EmployeeId");

                    b.HasIndex(new[] { "EmployeeId" }, "IX_Employee")
                        .IsUnique();

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("DAL.Entities.EmployeeAppliedForJob", b =>
                {
                    b.Property<int>("Cvid")
                        .HasColumnType("int")
                        .HasColumnName("CVID");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("JobId")
                        .HasColumnType("int")
                        .HasColumnName("JobID");

                    b.HasIndex("Cvid");

                    b.HasIndex("JobId");

                    b.ToTable("EmployeeAppliedForJob");
                });

            modelBuilder.Entity("DAL.Entities.Employer", b =>
                {
                    b.Property<string>("EmployerId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("EmployerID");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("EmployerId");

                    b.HasIndex(new[] { "EmployerId" }, "IX_Employer")
                        .IsUnique();

                    b.ToTable("Employer");
                });

            modelBuilder.Entity("DAL.Entities.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("JobID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("CityID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployerId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("EmployerID");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("EndSalary")
                        .HasColumnType("money");

                    b.Property<string>("JobImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobTitleId")
                        .HasColumnType("int")
                        .HasColumnName("JobTitleID");

                    b.Property<short>("JobType")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("SkillId")
                        .HasColumnType("int")
                        .HasColumnName("SkillID");

                    b.Property<short>("SkillLevel")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("StartSalary")
                        .HasColumnType("money");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobId");

                    b.HasIndex("CityId");

                    b.HasIndex("EmployerId");

                    b.HasIndex("JobTitleId");

                    b.HasIndex("SkillId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("DAL.Entities.JobTitle", b =>
                {
                    b.Property<int>("TitleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TitleID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TitleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TitleId");

                    b.ToTable("JobTitle");
                });

            modelBuilder.Entity("DAL.Entities.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReviewID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("JobId")
                        .HasColumnType("int")
                        .HasColumnName("JobID");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UserID");

                    b.HasKey("ReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("DAL.Entities.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SkillID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("SkillId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AvatarUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<short>("TypeUser")
                        .HasColumnType("smallint");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DAL.Entities.ContactEmployee", b =>
                {
                    b.HasOne("DAL.Entities.Cv", "Cv")
                        .WithMany()
                        .HasForeignKey("Cvid")
                        .HasConstraintName("FK_ContactEmployee_CV")
                        .IsRequired();

                    b.HasOne("DAL.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK_ContactEmployee_Employee");

                    b.HasOne("DAL.Entities.Skill", "JobSkillNavigation")
                        .WithMany()
                        .HasForeignKey("JobSkill")
                        .HasConstraintName("FK_ContactEmployee_Skill")
                        .IsRequired();

                    b.HasOne("DAL.Entities.JobTitle", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId")
                        .HasConstraintName("FK_ContactEmployee_JobTitle")
                        .IsRequired();

                    b.Navigation("Cv");

                    b.Navigation("Employee");

                    b.Navigation("JobSkillNavigation");

                    b.Navigation("JobTitle");
                });

            modelBuilder.Entity("DAL.Entities.Cv", b =>
                {
                    b.HasOne("DAL.Entities.Employee", "Employee")
                        .WithMany("Cvs")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK_CV_Employee");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DAL.Entities.Employee", b =>
                {
                    b.HasOne("DAL.Entities.User", "EmployeeNavigation")
                        .WithOne("Employee")
                        .HasForeignKey("DAL.Entities.Employee", "EmployeeId")
                        .HasConstraintName("FK_Employee_User")
                        .IsRequired();

                    b.Navigation("EmployeeNavigation");
                });

            modelBuilder.Entity("DAL.Entities.EmployeeAppliedForJob", b =>
                {
                    b.HasOne("DAL.Entities.Cv", "Cv")
                        .WithMany()
                        .HasForeignKey("Cvid")
                        .HasConstraintName("FK_EmployeeAppliedForJob_CV")
                        .IsRequired();

                    b.HasOne("DAL.Entities.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK_EmployeeAppliedForJob_Job")
                        .IsRequired();

                    b.Navigation("Cv");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("DAL.Entities.Employer", b =>
                {
                    b.HasOne("DAL.Entities.User", "EmployerNavigation")
                        .WithOne("Employer")
                        .HasForeignKey("DAL.Entities.Employer", "EmployerId")
                        .HasConstraintName("FK_Employer_User")
                        .IsRequired();

                    b.Navigation("EmployerNavigation");
                });

            modelBuilder.Entity("DAL.Entities.Job", b =>
                {
                    b.HasOne("DAL.Entities.City", "City")
                        .WithMany("Jobs")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_Job_City")
                        .IsRequired();

                    b.HasOne("DAL.Entities.Employer", "Employer")
                        .WithMany("Jobs")
                        .HasForeignKey("EmployerId")
                        .HasConstraintName("FK_Job_Employer");

                    b.HasOne("DAL.Entities.JobTitle", "JobTitle")
                        .WithMany("Jobs")
                        .HasForeignKey("JobTitleId")
                        .HasConstraintName("FK_Job_JobTitle")
                        .IsRequired();

                    b.HasOne("DAL.Entities.Skill", "Skill")
                        .WithMany("Jobs")
                        .HasForeignKey("SkillId")
                        .HasConstraintName("FK_Job_Skill")
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Employer");

                    b.Navigation("JobTitle");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("DAL.Entities.Review", b =>
                {
                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Review_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.City", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("DAL.Entities.Employee", b =>
                {
                    b.Navigation("Cvs");
                });

            modelBuilder.Entity("DAL.Entities.Employer", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("DAL.Entities.JobTitle", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("DAL.Entities.Skill", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Navigation("Employee");

                    b.Navigation("Employer");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}