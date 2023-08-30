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
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(x => x.Price).HasColumnType("money");
            
            builder.Property(x => x.SeatNumber).HasColumnName("Seat number");

            // Configure Relationships
            builder.HasOne(x => x.MovieShow)
                    .WithMany(x => x.Tikets)
                    .HasForeignKey(x => x.MovieShowId)
                    .IsRequired(false);

            builder.HasOne(x => x.TicketStatus)
                    .WithMany(x => x.Tickets)
                    .HasForeignKey(x => x.TicketStatusId)
                    .IsRequired(false);

            builder.HasOne(x => x.Booking)
                   .WithMany(x => x.Tickets)
                   .HasForeignKey(x => x.BookingId)
                   .IsRequired(false);
        }
    }
}
