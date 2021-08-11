using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TimeSheetWebApp.Models;

namespace TimeSheetWebApp.MyDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<Category>().HasData(
                new Category(1, "Design"),
                new Category(2, "Front-End Development")
            );

            modelBuilder.Entity<Country>().HasData(
               new Country(1, "Serbia"),
               new Country(2, "USA")
            );

            modelBuilder.Entity<Client>().HasData(
               new Client(1, "Clockwork", "Novosadska 9", "Novi Sad", "21421", 1),
               new Client(2, "NinaMedia", "Novosadska 9", "Novi Sad", "21421", 2)
            );

            modelBuilder.Entity<Employee>().HasData(
               new Employee(1, "Marko Markovic", "marko@gmail.com", "password", "marko123", true, 40, Role.Admin)
               //new Employee(2, "Jovana Jovanovic", "jovana@gmail.com", "password", "jovana123", true, 40, Role.Worker)
            );

            modelBuilder.Entity<Project>().HasData(
              new Project(1, "PWN", "Some description", 1, 1, ProjectStatus.Active)
              //new Project(2,"BuzzMonitors", "Some description", 1, 2, ProjectStatus.Active)
            );

            modelBuilder.Entity<TimeSheet>().HasData(
             new TimeSheet(1, new DateTime(2021, 2, 10, 8, 30, 52), 8, 1, "Some description", 1, 1, 1)
             );

            modelBuilder
             .Entity<Project>()
             .HasOne(p => p.Lead)
             .WithMany(c => c.LeadingProjects)
             .HasForeignKey(p => p.LeadId);

            modelBuilder
            .Entity<Project>()
            .HasMany(p => p.Employees)
            .WithMany(p => p.Projects);
           /* .UsingEntity(j => j.HasData(new { EmployeesId = 2, ProjectsId = 1 }*//*, new { EmployeesId = 1, ProjectsId = 2 }*//*));*/

           

            modelBuilder
            .Entity<Client>()
            .HasOne(p => p.Project)
            .WithOne(p => p.Client)
            .HasForeignKey<Project>(b => b.ClientId);

            modelBuilder
            .Entity<Client>()
            .HasOne(p => p.Country)
            .WithMany(c => c.Clients)
            .HasForeignKey(p => p.CountryId);

            modelBuilder
            .Entity<TimeSheet>()
            .HasOne(p => p.Category)
            .WithMany(c => c.TimeSheets)
            .HasForeignKey(p => p.CategoryId);

            modelBuilder
            .Entity<TimeSheet>()
            .HasOne(p => p.Employee)
            .WithMany(c => c.TimeSheets)
            .HasForeignKey(p => p.EmployeeId);

            modelBuilder
            .Entity<TimeSheet>()
            .HasOne(p => p.Project)
            .WithMany(c => c.TimeSheets)
            .HasForeignKey(p => p.ProjectId);

            modelBuilder.Entity<Project>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<Category>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<Client>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<Country>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<Employee>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<TimeSheet>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }
    }
}
