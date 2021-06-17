using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>().HasKey(k => k.Id);

            //modelBuilder.Entity<Aluno>().Property(p => p.Media).HasPrecision(1);
            //modelBuilder.Entity<Aluno>().Property(p => p.Media).HasColumnType("float(1)");
        }

        public DbSet<WebAPI.Models.Aluno> Aluno { get; set; }

    }
}
