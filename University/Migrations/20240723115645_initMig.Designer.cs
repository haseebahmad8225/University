﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityService.Data;

#nullable disable

namespace University.Migrations
{
    [DbContext(typeof(UniversityContext))]
    [Migration("20240723115645_initMig")]
    partial class initMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("University.Model.Department", b =>
                {
                    b.Property<long>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DepartmentId"), 1L, 1);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.HasKey("DepartmentId");

                    b.HasIndex("UniversityId");

                    b.ToTable("DepartmentDetails");
                });

            modelBuilder.Entity("University.Model.Student", b =>
                {
                    b.Property<long>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("StudentId"), 1L, 1);

                    b.Property<string>("AdmissionDate")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CNIC")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("DOB")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<long>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Religion")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<long>("TeacherId")
                        .HasColumnType("bigint");

                    b.HasKey("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("StudentDetails");
                });

            modelBuilder.Entity("University.Model.Teacher", b =>
                {
                    b.Property<long>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TeacherId"), 1L, 1);

                    b.Property<string>("CNIC")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<long>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("JoiningDate")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("TeacherId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("TeacherDetails");
                });

            modelBuilder.Entity("University.Model.UniversityDetails", b =>
                {
                    b.Property<long>("UniversityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UniversityId"), 1L, 1);

                    b.Property<int>("EstablishedYear")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("UniversityId");

                    b.ToTable("UniversityDetails");
                });

            modelBuilder.Entity("University.Model.Department", b =>
                {
                    b.HasOne("University.Model.UniversityDetails", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("University.Model.Student", b =>
                {
                    b.HasOne("University.Model.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("University.Model.Teacher", b =>
                {
                    b.HasOne("University.Model.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
