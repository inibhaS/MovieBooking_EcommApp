using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//combination of primarykey
            //actor_movie table is the joining table
            //so we definining one to many relationship between 
            modelBuilder.Entity<Actor_Movies>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<Actor_Movies>().HasOne(m => m.Movie).WithMany
                (am => am.Actors_Movies).HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<Actor_Movies>().HasOne(m => m.Actor).WithMany
                (am => am.Actors_Movies).HasForeignKey(m => m.ActorId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Actor_Movies> Actors_Movies { get; set; }
        public DbSet<Cinema>Cinemas { get; set; }
        public DbSet<Movie>Movies { get; set; }
        public DbSet<Producer>Producers { get; set; }


    }
}
