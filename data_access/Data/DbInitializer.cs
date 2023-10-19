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

            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User() { Id = 1, Name="John", Surname="Green", Email="johngreen@gmail.com", Phone="0953829563"},
                new User() { Id = 2, Name="Bella", Surname="White", Email="bellawhite@gmail.com", Phone="0985390462"},
                new User() { Id = 3, Name="Frank", Surname="Black", Email="frankblach@gmail.com", Phone="0975849602"},
            });

            // Ініціалізація фільмів, рейтингів та сеансів
            for (int i = 1; i <= 15; i++)
            {
                modelBuilder.Entity<Film>().HasData(new Film
                {
                    Id = i,
                    Name = $"Film {i}",
                    Year = DateTime.Now.AddYears(-i),
                    Description = $"Description to film {i}",
                    Director = $"Direcor {i}",
                    Duration = TimeSpan.FromMinutes(120),
                    GenreId = i % 10 + 1,
                });

                modelBuilder.Entity<Rating>().HasData(new Rating
                {
                    Id = i,
                    Estimate = i % 5 + 1,
                    Review = $"Review to film {i}",
                    FilmId = i,
                });

                // Ініціалізація сеансів на наступний тиждень
                DateTime currentDate = DateTime.Now.AddDays(1);
                for (int j = 1; j <= 7; j++)
                {
                    for (int k = 1; k <= 10; k++)
                    {
                        modelBuilder.Entity<MovieShow>().HasData(new MovieShow
                        {
                            Id = (i - 1) * 70 + (j - 1) * 10 + k,
                            StartDateTime = currentDate.Date.AddHours(10 + k),
                            FilmId = i,
                            CinemaHallId = j % 3 + 1,
                        });
                    }
                    currentDate = currentDate.AddDays(1);
                }
            }
            // Ініціалізація квитків для всіх сеансів
            int ticketIdCounter = 1;
            var random = new Random();

            // Перебираємо всі сеанси
            foreach (var movieShowId in Enumerable.Range(1, 15 * 7 * 10)) // 15 фільмів * 7 днів * 10 сеансів
            {
                var ticketStatusId = 1;
                var price = random.Next(50, 200); // Випадкова ціна квитка
                var seatNumber = random.Next(1, 101); // Випадковий номер місця

                modelBuilder.Entity<Ticket>().HasData(new Ticket
                {
                    Id = ticketIdCounter,
                    SeatNumber = seatNumber,
                    Price = price,
                    TicketStatusId = ticketStatusId,
                    MovieShowId = movieShowId,
                });

                ticketIdCounter++;
            }

        }
    }
}
