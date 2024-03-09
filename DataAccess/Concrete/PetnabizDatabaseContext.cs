using Autofac.Core;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

public class PetnabizDatabaseContext : IdentityDbContext<AppUser, AppRole, int>
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=petnabizdb;Initial Catalog=PetnabizDatabase;User ID=sa;Password=password@w3ypet");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        //modelBuilder.Entity<Vet>()
        //    .HasOne(v => v.VeterinaryClinic)
        //    .WithMany(v => v.Vets)
        //    .HasForeignKey(v => v.ClinicId);

        //modelBuilder.Entity<Examination>()
        //    .HasOne(p => p.Pet)
        //    .WithMany(p => p.Examinations)
        //    .HasForeignKey(p => p.PetId);

        //modelBuilder.Entity<Examination>()
        //    .HasOne(p => p.Vet)
        //    .WithMany(p => p.Examinations)
        //    .HasForeignKey(p => p.VetId);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<VeterinaryClinic> VeterinaryClinics { get; set; }
    public DbSet<Vet> Vets { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Examination> Examinations { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
}
