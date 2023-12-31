﻿using data_access.Data.Configurations;
using data_access.Entities;
using data_access.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<CinemaHall> CinemaHalls { get; set; } = null!;
        public DbSet<Film> Films { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<MovieShow> MovieShows { get; set; } = null!;
        public DbSet<Rating> Ratings { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<TicketStatus> TicketStatuses { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        //Connection ---------------------------------------
        public string connectionString;

        public ApplicationContext()
        {
            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cinema;Integrated Security=True;Connect Timeout=2;";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        //Connection ---------------------------------------

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new CinemaHallConfiguration());
            modelBuilder.ApplyConfiguration(new FilmConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieShowConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new TicketStatusConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            DbInitializer.SeedData(modelBuilder);
        }
    }
}
