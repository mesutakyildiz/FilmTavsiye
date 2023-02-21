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
    public class UserNoteConfiguration : IEntityTypeConfiguration<UserNote>
    {
        public void Configure(EntityTypeBuilder<UserNote> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Score).HasColumnType("money");
            builder.HasOne(x => x.UserApp).WithMany(y => y.UserNotes).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Movie).WithMany(y => y.UserNotes).HasForeignKey(x => x.MovieId);
            builder.ToTable(nameof(UserNote)); 
        }
    }
}
