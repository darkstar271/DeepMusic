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


        public DbSet<Artist> Artist { get; set; }
        public DbSet<Albums> Albums { get; set; }
        public DbSet<Tracks> Tracks { get; set; }
        public DbSet<Genres> Genres { get; set; }

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
