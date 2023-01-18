﻿
using E_ticket.Models;
using Microsoft.EntityFrameworkCore;

namespace E_ticket.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>().HasKey(am => new { am.MovieId, am.ActorId });
            modelBuilder.Entity<MovieActor>().HasOne(am => am.Movie).WithMany(am => am.movieActors).HasForeignKey(am => am.MovieId);
            modelBuilder.Entity<MovieActor>().HasOne(am => am.Actor).WithMany(am => am.MovieActors).HasForeignKey(am => am.ActorId);
        }

        public DbSet<Cinema> cinemas { get; set; }

        public DbSet<Producer> producers { get; set; }

        public DbSet<Movie> movies { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<MovieActor> movieActors { get; set; }

    }
}