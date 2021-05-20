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
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseLazyLoadingProxies();
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
                   .HasOne(b => b.generer)
                   .WithOne(i => i.candidat)
                   .HasForeignKey<Generer>(b => b.CandidatId);

                modelBuilder.Entity<Candidat>()
                    .HasMany(pt => pt.Langue)
                    .WithOne(p => p.candidat);
                //.OnDelete(DeleteBehavior.Cascade);

                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Candidat>()
                  .HasMany(pt => pt.Experience_prof)
                  .WithOne(p => p.candidat);
                //.OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Candidat>()
                  .HasMany(pt => pt.Competence)
                  .WithOne(p => p.candidat);
                //.OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Candidat>()
                  .HasMany(pt => pt.Hobby)
                  .WithOne(p => p.candidat);
                //.OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Candidat>()
                  .HasMany(pt => pt.Commentaire)
                  .WithOne(p => p.candidat);
                //.OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Candidat>()
                 .HasMany(pt => pt.Formation)
                 .WithOne(p => p.candidat);
                //.OnDelete(DeleteBehavior.Cascade);
                modelBuilder.Entity<Offre>()
              .HasMany(pt => pt.Competence)
              .WithOne(p => p.offre)
              .OnDelete(DeleteBehavior.Restrict);
                modelBuilder.Entity<Offre>()
                 .HasMany(pt => pt.Diplome)
                 .WithOne(p => p.offre)
                  .OnDelete(DeleteBehavior.Restrict);
                modelBuilder.Entity<Offre>()
                 .HasMany(pt => pt.Langue)
                 .WithOne(p => p.offre)
                .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<Offre>()
                  .HasMany(pt => pt.Questionnaire)
                  .WithOne(p => p.offre)
                 .OnDelete(DeleteBehavior.Restrict);

               modelBuilder.Entity<Candidat>()
               .HasMany(pt => pt.candidatures)
               .WithOne(p => p.candidat)
                 .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<Offre>()
                .HasMany(pt => pt.Candidature)
                .WithOne(p => p.offre)
                .OnDelete(DeleteBehavior.Restrict);
                base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Linkedin>()
           .HasOne(pt => pt.candidat)
           .WithOne(p => p.linkedin)
           .HasForeignKey<Linkedin>(c => c.id_candidat);
            //.OnDelete(DeleteBehavior.Cascade);

            // .OnDelete(DeleteBehavior.Restrict);


        }

        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<Candidature> Candidature { get; set; }

        public DbSet<Responsable_RH> Responsable_RH { get; set; }
        public DbSet<Experience_prof> Experience_prof { get; set; }
        public DbSet<Formation> Formation { get; set; }
        public DbSet<Generer> Generer { get; set; }
        public DbSet<Langue> Langues { get; set; }
        public DbSet<Competence> Competence { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Formation> Formations { get; set; }
        public DbSet<Commentaire> Commentaire { get; set; }
        public DbSet<Offre> Offre { get; set; }
        public DbSet<Diplome>Diplome { get; set; }
        public DbSet<Questionnaire> Questionnaire { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Linkedin> Linkedins { get; set; }
        public DbSet<Diplome> Diplomes { get; set; }
        public DbSet<Offre> Offres { get; set; }
        public DbSet<Candidature> Candidatures { get; set; }
    }
}
