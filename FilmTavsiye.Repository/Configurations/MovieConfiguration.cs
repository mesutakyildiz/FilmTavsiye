using FilmTavsiye.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTavsiye.Repository.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.ApiId);
            builder.Property(x => x.ApiId).IsRequired();
            builder.Property(x => x.Popularity).HasColumnType("money");
            builder.Property(x => x.VoteAverage).HasColumnType("money");
            builder.ToTable(nameof(Movie));
        }
    }
}
