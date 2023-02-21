using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FilmTavsiye.Core.Models;

namespace FilmTavsiye.Repository
{
    // Identity üyelik tablolar
    //

    public class AppDbContext : IdentityDbContext<UserApp, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

        {
        }

        public DbSet<Movie> Movies{ get; set; }
        public DbSet<UserNote> UserNotes{ get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            builder.Entity<UserApp>().HasIndex(x => x.Email).IsUnique();
            builder.Entity<UserApp>().HasIndex(x => x.PhoneNumber).IsUnique();
  
            base.OnModelCreating(builder);
        }
  
    }
}