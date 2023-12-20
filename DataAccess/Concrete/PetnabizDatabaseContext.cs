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
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PetnabizDatabase;Trusted_Connection=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        modelBuilder.Entity<Vet>()
            .HasOne(v => v.VeterinaryClinic)
            .WithMany(v => v.Vets)
            .HasForeignKey(v => v.ClinicId);

        //modelBuilder.Entity<PetOwner>()
        //    .HasOne(p => p.VeterinaryClinic)
        //    .WithMany(p => p.PetOwners)
        //    .HasForeignKey(p => p.ClinicId);

        //modelBuilder.Entity<Pet>()
        //    .HasOne(p => p.PetOwner)
        //    .WithMany(p => p.Pets)
        //    .HasForeignKey(p => p.OwnerId);

        modelBuilder.Entity<Examination>()
            .HasOne(p => p.Pet)
            .WithMany(p => p.Examinations)
            .HasForeignKey(p => p.PetId);

        modelBuilder.Entity<Examination>()
            .HasOne(p => p.Vet)
            .WithMany(p => p.Examinations)
            .HasForeignKey(p => p.VetId);

        //modelBuilder.Entity<Examination>()
        //    .HasOne(p => p.PetOwner)
        //    .WithMany(p => p.Examinations)
        //    .HasForeignKey(p => p.PetOwnerId);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<VeterinaryClinic> VeterinaryClinics { get; set; }
    public DbSet<Vet> Vets { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Examination> Examinations { get; set; }

    //public DbSet<User> Users { get; set; }
    //public DbSet<OperationClaim> OperationClaims { get; set; }
    //public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
}
