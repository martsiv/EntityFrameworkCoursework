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
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            // Configure Relationships
            builder.HasOne(x => x.Genre)
                    .WithMany(x => x.Films)
                    .HasForeignKey(x => x.GenreId)
                    .IsRequired(false);
        }
    }
}
