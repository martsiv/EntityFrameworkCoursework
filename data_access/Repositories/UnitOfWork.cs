using data_access.Data;
using data_access.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Repositories
{
    public interface IUoW
    {
        IRepository<Booking> BookingRepo { get; }
        IRepository<CinemaHall> CinemaHallRepo { get; }
        IRepository<Film> FilmRepo { get; }
        IRepository<Genre> GenreRepo { get; }
        IRepository<MovieShow> MovieShowRepo { get; }
        IRepository<Rating> RatingRepo { get; }
        IRepository<Ticket> TicketRepo { get; }
        IRepository<TicketStatus> TicketStatusRepo { get; }
        IRepository<User> UserRepo { get; }
        void Save();
    }

    public class UnitOfWork : IUoW, IDisposable
    {
        private static ApplicationContext context = null;
        private IRepository<Booking>? bookingRepo = null;
        private IRepository<CinemaHall?> cinemaHallRepo = null;
        private IRepository<Film?> filmRepo = null;
        private IRepository<Genre?> genreRepo = null;
        private IRepository<MovieShow?> movieShowRepo = null;
        private IRepository<Rating?> ratingRepo = null;
        private IRepository<Ticket?> ticketRepo = null;
        private IRepository<TicketStatus?> ticketStatusRepo = null;
        private IRepository<User?> userRepo = null;
        public UnitOfWork(DbContextOptions<ApplicationContext> option)
        {
            ApplicationContext context = new ApplicationContext(option);
        }
        public IRepository<Booking> BookingRepo
        {
            get
            {
                if (this.bookingRepo == null)
                {
                    this.bookingRepo = new Repository<Booking>(context);
                }
                return bookingRepo;
            }
        }
        public IRepository<CinemaHall> CinemaHallRepo
        {
            get
            {
                if (this.cinemaHallRepo == null)
                {
                    this.cinemaHallRepo = new Repository<CinemaHall>(context);
                }
                return cinemaHallRepo;
            }
        }

        public IRepository<Film> FilmRepo
        {
            get
            {
                if (this.filmRepo == null)
                {
                    this.filmRepo = new Repository<Film>(context);
                }
                return filmRepo;
            }
        }
        public IRepository<Genre> GenreRepo
        {
            get
            {
                if (this.genreRepo == null)
                {
                    this.genreRepo = new Repository<Genre>(context);
                }
                return genreRepo;
            }
        }
        public IRepository<MovieShow> MovieShowRepo
        {
            get
            {
                if (this.movieShowRepo == null)
                {
                    this.movieShowRepo = new Repository<MovieShow>(context);
                }
                return movieShowRepo;
            }
        }
        public IRepository<Rating> RatingRepo
        {
            get
            {
                if (this.ratingRepo == null)
                {
                    this.ratingRepo = new Repository<Rating>(context);
                }
                return ratingRepo;
            }
        }
        public IRepository<Ticket> TicketRepo
        {
            get
            {
                if (this.ticketRepo == null)
                {
                    this.ticketRepo = new Repository<Ticket>(context);
                }
                return ticketRepo;
            }
        }
        public IRepository<TicketStatus> TicketStatusRepo
        {
            get
            {
                if (this.ticketStatusRepo == null)
                {
                    this.ticketStatusRepo = new Repository<TicketStatus>(context);
                }
                return ticketStatusRepo;
            }
        }
        public IRepository<User> UserRepo
        {
            get
            {
                if (this.userRepo == null)
                {
                    this.userRepo = new Repository<User>(context);
                }
                return userRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
