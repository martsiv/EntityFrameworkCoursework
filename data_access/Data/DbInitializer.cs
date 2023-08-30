using data_access.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace data_access.Data
{
    public class DbInitializer
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre() { Id = 1, Name="Action"},
                new Genre() { Id = 2, Name="Comedy"},
                new Genre() { Id = 3, Name="Drama"},
                new Genre() { Id = 4, Name="Horror"},
                new Genre() { Id = 5, Name="ScienceFiction"},
                new Genre() { Id = 6, Name="Fantasy"},
                new Genre() { Id = 7, Name="Thriller"},
                new Genre() { Id = 8, Name="Romance"},
                new Genre() { Id = 9, Name="Adventure"},
                new Genre() { Id = 10, Name="Animation"},
            });
            modelBuilder.Entity<TicketStatus>().HasData(new TicketStatus[]
            {
                new TicketStatus() { Id = 1, StatusName="Available"},
                new TicketStatus() { Id = 2, StatusName="Sold"},
                new TicketStatus() { Id = 3, StatusName="Booked"},
            });
            modelBuilder.Entity<CinemaHall>().HasData(new CinemaHall[]
            {
                new CinemaHall() { Id = 1, HallName="Red hall", NumberOfSeats=60},
                new CinemaHall() { Id = 2, HallName="Black hall", NumberOfSeats=100},
                new CinemaHall() { Id = 3, HallName="Green hall", NumberOfSeats=30},
            });
        }
    }
}
