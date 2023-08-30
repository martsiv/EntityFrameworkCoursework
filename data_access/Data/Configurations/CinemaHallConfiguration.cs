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
    public class CinemaHallConfiguration : IEntityTypeConfiguration<CinemaHall>
    {
        public void Configure(EntityTypeBuilder<CinemaHall> builder)
        {
            builder.Property(x => x.HallName).HasMaxLength(100).HasColumnName("Hall name");
            builder.Property(x => x.NumberOfSeats).HasColumnName("Number of seats");
        }
    }
}
