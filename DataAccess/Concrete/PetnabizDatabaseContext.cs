using Autofac.Core;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete;

public class PetnabizDatabaseContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PetnabizDatabase;Trusted_Connection=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        modelBuilder.Entity<Vet>()
            .HasOne(v => v.Manager)
            .WithOne(v => v.Vet)
            .HasForeignKey<Manager>(m => m.VetId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Vet)
            .WithMany(u => u.Users)
            .HasForeignKey(u => u.VetId);

        modelBuilder.Entity<Patient>()
            .HasOne(p => p.Vet)
            .WithMany(p => p.Patients)
            .HasForeignKey(p => p.VetId);

        modelBuilder.Entity<Patient>()
            .HasOne(p => p.User)
            .WithMany(p => p.Patients)
            .HasForeignKey(p => p.UserId);
    }

    public DbSet<Vet> Vets { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
}
