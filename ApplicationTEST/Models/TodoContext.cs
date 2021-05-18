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

          /*  modelBuilder.Entity<Candidat>()
           .HasOne(b => b.generer)
           .WithOne(i => i.candidat)
           .HasForeignKey<Generer>(b => b.CandidatId);*/

            modelBuilder.Entity<Candidat>()
                .HasMany(pt => pt.langues)
                .WithOne(p => p.candidat);
            //.OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Candidat>()
              .HasMany(pt => pt.experiences)
              .WithOne(p => p.candidat);
            //.OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Candidat>()
              .HasMany(pt => pt.competences)
              .WithOne(p => p.candidat);
            //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Candidat>()
              .HasMany(pt => pt.hobbies)
              .WithOne(p => p.candidat);
            //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Candidat>()
             .HasMany(pt => pt.formations)
             .WithOne(p => p.candidat);
            //.OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Linkedin>()
             .HasOne(pt => pt.candidat)
             .WithOne(p => p.linkedin)
             .HasForeignKey<Linkedin>(c => c.id_candidat);
            //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Offre>()
           .HasMany(pt => pt.diplomes)
           .WithOne(p => p.offre);
            //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Offre>()
           .HasMany(pt => pt.competences)
           .WithOne(p => p.offre);

            modelBuilder.Entity<Offre>()
          .HasMany(pt => pt.langues)
          .WithOne(p => p.offre);

            modelBuilder.Entity<Offre>()
            .Navigation(b => b.langues)
            .UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.Entity<Candidat>()
           .HasMany(pt => pt.candidatures)
           .WithOne(p => p.candidat);

            modelBuilder.Entity<Offre>()
            .HasMany(pt => pt.candidatures)
            .WithOne(p => p.offre);

            base.OnModelCreating(modelBuilder);

        }
        
        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<Responsable_RH> Responsable_RH { get; set; }
        public DbSet<Experience_prof> Experience_prof { get; set; }
        public DbSet<Generer> Generer { get; set; }
        public DbSet<Langue> Langues { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Formation> Formations { get; set; }
        public DbSet<Linkedin> Linkedins { get; set; }
        public DbSet<Diplome> Diplomes { get; set; }
        public DbSet<Offre> Offres { get; set; }
        public DbSet<Candidature> Candidatures { get; set; }
    }
}
