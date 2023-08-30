using data_access.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Data.Configurations
{
    public class MovieShowConfiguration : IEntityTypeConfiguration<MovieShow>
    {
        public void Configure(EntityTypeBuilder<MovieShow> builder)
        {
            builder.Property(x => x.StartDateTime).HasColumnName("Start session");
            // Configure Relationships
            builder.HasOne(x => x.Film)
                    .WithMany(x => x.MovieShows)
                    .HasForeignKey(x => x.FilmId)
                    .IsRequired(false);

            builder.HasOne(x => x.CinemaHall)
                    .WithMany(x => x.MovieShows)
                    .HasForeignKey(x => x.CinemaHallId)
                    .IsRequired(false);
        }
    }
}
