﻿// <auto-generated />
using System;
using CMS.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CMS.Infrastructure.Migrations
{
    [DbContext(typeof(CMSDbContext))]
    partial class CMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CMS.Domain.Entities.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DateId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentAttendanceId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DateId");

                    b.HasIndex("StudentAttendanceId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Auth.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CMS.Domain.Entities.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte>("Grade")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DateId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DateId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Examine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<int>("Coin")
                        .HasColumnType("integer");

                    b.Property<Guid>("DateId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Task")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("DateId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Examines");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Homework", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Coin")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uuid");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Homeworks");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AttendanceId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<int?>("Day")
                        .HasColumnType("integer");

                    b.Property<Guid?>("FromTimeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ToTimeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AttendanceId")
                        .IsUnique();

                    b.HasIndex("ClassId");

                    b.HasIndex("FromTimeId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("ToTimeId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HomeNumber")
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Models.CustomeDate", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Day")
                        .HasColumnType("integer");

                    b.Property<int>("Month")
                        .HasColumnType("integer");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("CustomeDate");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Models.CustomeTime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Hour")
                        .HasColumnType("integer");

                    b.Property<int>("Minute")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("CustomeTime");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Models.StudentAttendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsPresent")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uuid");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentAttendances");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Quiz", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<char>("CorrectAnswer")
                        .HasColumnType("character(1)");

                    b.Property<string>("DescriptionPhotoPath")
                        .HasColumnType("text");

                    b.Property<Guid?>("LessonId")
                        .HasColumnType("uuid");

                    b.Property<string>("OptionsA")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OptionsB")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OptionsC")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OptionsD")
                        .HasColumnType("text");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("CMS.Domain.Entities.School", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("ClassCount")
                        .HasColumnType("integer");

                    b.Property<int?>("EmployeesCount")
                        .HasColumnType("integer");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("text");

                    b.Property<int?>("StudentCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CMS.Domain.Entities.Auth.Employee", b =>
                {
                    b.HasBaseType("CMS.Domain.Entities.Auth.User");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uuid");

                    b.Property<string>("PDFPath")
                        .HasColumnType("text");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("text");

                    b.HasIndex("LocationId");

                    b.ToTable("AspNetUsers", t =>
                        {
                            t.Property("Gender")
                                .HasColumnName("Employee_Gender");

                            t.Property("LocationId")
                                .HasColumnName("Employee_LocationId");

                            t.Property("PDFPath")
                                .HasColumnName("Employee_PDFPath");

                            t.Property("PhotoPath")
                                .HasColumnName("Employee_PhotoPath");
                        });

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Auth.Student", b =>
                {
                    b.HasBaseType("CMS.Domain.Entities.Auth.User");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<int>("Coin")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("Gender")
                        .HasColumnType("integer");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uuid");

                    b.Property<string>("PDFPath")
                        .HasColumnType("text");

                    b.Property<string>("ParentsPhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("text");

                    b.HasIndex("ClassId");

                    b.HasIndex("LocationId");

                    b.ToTable("AspNetUsers", t =>
                        {
                            t.Property("Gender")
                                .HasColumnName("Student_Gender");

                            t.Property("LocationId")
                                .HasColumnName("Student_LocationId");

                            t.Property("PDFPath")
                                .HasColumnName("Student_PDFPath");

                            t.Property("PhotoPath")
                                .HasColumnName("Student_PhotoPath");
                        });

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Auth.Teacher", b =>
                {
                    b.HasBaseType("CMS.Domain.Entities.Auth.User");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uuid");

                    b.Property<string>("PDFPath")
                        .HasColumnType("text");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("text");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uuid");

                    b.HasIndex("LocationId");

                    b.HasIndex("SubjectId");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Attendance", b =>
                {
                    b.HasOne("CMS.Domain.Entities.Models.CustomeDate", "Date")
                        .WithMany()
                        .HasForeignKey("DateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CMS.Domain.Entities.Models.StudentAttendance", "StudentAttendance")
                        .WithMany()
                        .HasForeignKey("StudentAttendanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Date");

                    b.Navigation("StudentAttendance");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Class", b =>
                {
                    b.HasOne("CMS.Domain.Entities.Auth.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Event", b =>
                {
                    b.HasOne("CMS.Domain.Entities.Models.CustomeDate", "Date")
                        .WithMany()
                        .HasForeignKey("DateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Date");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Examine", b =>
                {
                    b.HasOne("CMS.Domain.Entities.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("CMS.Domain.Entities.Models.CustomeDate", "Date")
                        .WithMany()
                        .HasForeignKey("DateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CMS.Domain.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("Class");

                    b.Navigation("Date");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Homework", b =>
                {
                    b.HasOne("CMS.Domain.Entities.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Lesson", b =>
                {
                    b.HasOne("CMS.Domain.Entities.Attendance", "Attendance")
                        .WithOne("Lesson")
                        .HasForeignKey("CMS.Domain.Entities.Lesson", "AttendanceId");

                    b.HasOne("CMS.Domain.Entities.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("CMS.Domain.Entities.Models.CustomeTime", "FromTime")
                        .WithMany()
                        .HasForeignKey("FromTimeId");

                    b.HasOne("CMS.Domain.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.HasOne("CMS.Domain.Entities.Auth.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CMS.Domain.Entities.Models.CustomeTime", "ToTime")
                        .WithMany()
                        .HasForeignKey("ToTimeId");

                    b.Navigation("Attendance");

                    b.Navigation("Class");

                    b.Navigation("FromTime");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");

                    b.Navigation("ToTime");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Models.StudentAttendance", b =>
                {
                    b.HasOne("CMS.Domain.Entities.Lesson", "Lesson")
                        .WithMany("StudentAttendances")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CMS.Domain.Entities.Auth.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Quiz", b =>
                {
                    b.HasOne("CMS.Domain.Entities.Lesson", "Lesson")
                        .WithMany("Quizzes")
                        .HasForeignKey("LessonId");

                    b.HasOne("CMS.Domain.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("Lesson");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("CMS.Domain.Entities.School", b =>
                {
                    b.HasOne("CMS.Domain.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Subject", b =>
                {
                    b.HasOne("CMS.Domain.Entities.Class", "Class")
                        .WithMany("Subjects")
                        .HasForeignKey("ClassId");

                    b.Navigation("Class");
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
                    b.HasOne("CMS.Domain.Entities.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CMS.Domain.Entities.Auth.User", null)
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

                    b.HasOne("CMS.Domain.Entities.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CMS.Domain.Entities.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CMS.Domain.Entities.Auth.Employee", b =>
                {
                    b.HasOne("CMS.Domain.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Auth.Student", b =>
                {
                    b.HasOne("CMS.Domain.Entities.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId");

                    b.HasOne("CMS.Domain.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Auth.Teacher", b =>
                {
                    b.HasOne("CMS.Domain.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CMS.Domain.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("Location");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Attendance", b =>
                {
                    b.Navigation("Lesson")
                        .IsRequired();
                });

            modelBuilder.Entity("CMS.Domain.Entities.Class", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("CMS.Domain.Entities.Lesson", b =>
                {
                    b.Navigation("Quizzes");

                    b.Navigation("StudentAttendances");
                });
#pragma warning restore 612, 618
        }
    }
}
