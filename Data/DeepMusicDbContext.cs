using System;
using System.Collections.Generic;
using System.Text;
using DeepMusic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DeepMusic.Data
{
    public class DeepMusicDbContext : DbContext
    {
        // This is part of making the database, it's used with the Entity Framework Core commands, like add-migration.

        // Here we add in all the tables we are using.
        // < this is the name of the database "Artist"> this is the name of the Table "Artist"
        // and it will build the columns  from what's in the Tables class.
        public DbSet<Artist> Artist { get; set; }// this points to Models/Artist fields, that will build the database
        public DbSet<Albums> Albums { get; set; }
        public DbSet<Tracks> Tracks { get; set; }
        public DbSet<Genres> Genres { get; set; }

        // We need 2 constructors, one is empty, and the other injects in DbContextOptions

        public DeepMusicDbContext(DbContextOptions<DeepMusicDbContext> options)
            : base(options)
        {
        }

        public DeepMusicDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
