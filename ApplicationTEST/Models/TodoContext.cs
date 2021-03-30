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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        


        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<CV> CVs { get; set; }


    }
}
