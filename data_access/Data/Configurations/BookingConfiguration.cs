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
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(x => x.BookingDate).HasColumnName("Booking date");
            builder.Property(x => x.Status).IsRequired(true);

            // Configure Relationships
            builder.HasOne(x => x.User)
                    .WithMany(x => x.Bookings)
                    .HasForeignKey(x => x.UserId)
                    .IsRequired(false);
        }
    }
}
