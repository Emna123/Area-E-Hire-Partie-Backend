using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApplicationTEST.Models
{
    public class TodoContext : IdentityDbContext<Candidat>
    {
        public TodoContext(DbContextOptions<TodoContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
      
     
  
        modelBuilder.Entity<Formation>() 
            .HasOne(pt => pt.generer) 
            .WithMany(p => p.formations) 
            .HasForeignKey("id_generer");
        modelBuilder.Entity<Experience_prof>() 
            .HasOne(pt => pt.generer) 
            .WithMany(p => p.experience_profs) 
            .HasForeignKey("id_generer");
        modelBuilder.Entity<Candidat>() 
            .HasOne(pt => pt.generer) 
            .WithOne(p => p.candidat) 
            .HasForeignKey<Candidat>(b => b.GenererId);

            base.OnModelCreating(modelBuilder);

        }
        


        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<Responsable_RH> Responsable_RH { get; set; }
        public DbSet<Experience_prof> Experience_prof { get; set; }

        public DbSet<Formation> Formation { get; set; }
        public DbSet<Generer> Generer { get; set; }

    }
}
