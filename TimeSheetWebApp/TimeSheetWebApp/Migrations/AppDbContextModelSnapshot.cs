﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeSheetWebApp.MyDbContext;

namespace TimeSheetWebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeProject", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("EmployeeProject");
                });

            modelBuilder.Entity("TimeSheetWebApp.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Design"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Front-End Development"
                        });
                });

            modelBuilder.Entity("TimeSheetWebApp.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(5)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Novosadska 9",
                            City = "Novi Sad",
                            CountryId = 1,
                            IsDeleted = false,
                            Name = "Clockwork",
                            PostalCode = "21421"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Novosadska 9",
                            City = "Novi Sad",
                            CountryId = 2,
                            IsDeleted = false,
                            Name = "NinaMedia",
                            PostalCode = "21421"
                        });
                });

            modelBuilder.Entity("TimeSheetWebApp.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Serbia"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "USA"
                        });
                });

            modelBuilder.Entity("TimeSheetWebApp.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<float>("HoursPerWeek")
                        .HasColumnType("real");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "marko@gmail.com",
                            HoursPerWeek = 40f,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Marko Markovic",
                            Password = "password",
                            Role = 0,
                            Username = "marko123"
                        });
                });

            modelBuilder.Entity("TimeSheetWebApp.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LeadId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.HasIndex("LeadId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            Description = "Some description",
                            IsDeleted = false,
                            LeadId = 1,
                            Name = "PWN",
                            Status = 0
                        });
                });

            modelBuilder.Entity("TimeSheetWebApp.Models.TimeSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<float>("Overtime")
                        .HasColumnType("real");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<float>("Time")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("TimeSheets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Date = new DateTime(2021, 2, 10, 8, 30, 52, 0, DateTimeKind.Unspecified),
                            Description = "Some description",
                            EmployeeId = 1,
                            IsDeleted = false,
                            Overtime = 1f,
                            ProjectId = 1,
                            Time = 8f
                        });
                });

            modelBuilder.Entity("EmployeeProject", b =>
                {
                    b.HasOne("TimeSheetWebApp.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeSheetWebApp.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TimeSheetWebApp.Models.Client", b =>
                {
                    b.HasOne("TimeSheetWebApp.Models.Country", "Country")
                        .WithMany("Clients")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("TimeSheetWebApp.Models.Project", b =>
                {
                    b.HasOne("TimeSheetWebApp.Models.Client", "Client")
                        .WithOne("Project")
                        .HasForeignKey("TimeSheetWebApp.Models.Project", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeSheetWebApp.Models.Employee", "Lead")
                        .WithMany("LeadingProjects")
                        .HasForeignKey("LeadId");

                    b.Navigation("Client");

                    b.Navigation("Lead");
                });

            modelBuilder.Entity("TimeSheetWebApp.Models.TimeSheet", b =>
                {
                    b.HasOne("TimeSheetWebApp.Models.Category", "Category")
                        .WithMany("TimeSheets")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeSheetWebApp.Models.Employee", "Employee")
                        .WithMany("TimeSheets")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeSheetWebApp.Models.Project", "Project")
                        .WithMany("TimeSheets")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("TimeSheetWebApp.Models.Category", b =>
                {
                    b.Navigation("TimeSheets");
                });

            modelBuilder.Entity("TimeSheetWebApp.Models.Client", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("TimeSheetWebApp.Models.Country", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("TimeSheetWebApp.Models.Employee", b =>
                {
                    b.Navigation("LeadingProjects");

                    b.Navigation("TimeSheets");
                });

            modelBuilder.Entity("TimeSheetWebApp.Models.Project", b =>
                {
                    b.Navigation("TimeSheets");
                });
#pragma warning restore 612, 618
        }
    }
}
