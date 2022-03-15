
using GerenciadorDeCursos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Data
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options): base(options)
        { 

        }

        public DbSet<Course> Course { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>(e =>
            {
                e.HasKey(p => p.id);
                e.Property(p => p.Title).IsRequired().HasMaxLength(200);
                e.Property(p => p.time).IsRequired().HasMaxLength(10);
                e.Property(p => p.status).IsRequired();
            });
        }
    }
}
