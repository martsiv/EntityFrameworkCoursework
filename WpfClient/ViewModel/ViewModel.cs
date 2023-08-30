using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using data_access.Data;
using data_access.Entities;
using data_access.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PropertyChanged;
using WpfClient.Help;
using static System.Reflection.Metadata.BlobBuilder;

namespace WpfClient.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        private ObservableCollection<Booking> bookings = new ObservableCollection<Booking>();
        private ObservableCollection<CinemaHall> cinemaHalls = new ObservableCollection<CinemaHall>();
        private ObservableCollection<Film> films = new ObservableCollection<Film>();
        private ObservableCollection<Genre> genres = new ObservableCollection<Genre>();
        private ObservableCollection<MovieShow> movieShows = new ObservableCollection<MovieShow>();
        private ObservableCollection<Rating> ratings = new ObservableCollection<Rating>();
        private ObservableCollection<Ticket> tickets = new ObservableCollection<Ticket>();
        private ObservableCollection<TicketStatus> ticketStatuses = new ObservableCollection<TicketStatus>();
        private ObservableCollection<User> users = new ObservableCollection<User>();
        public IEnumerable<Booking> Bookings => bookings;
        public IEnumerable<CinemaHall> CinemaHalls => cinemaHalls;
        public IEnumerable<Film> Films => films;
        public IEnumerable<Genre> Genres => genres;
        public IEnumerable<MovieShow> MovieShows => movieShows;
        public IEnumerable<Rating> Ratings => ratings;
        public IEnumerable<Ticket> Tickets => tickets;
        public IEnumerable<TicketStatus> TicketStatuses => ticketStatuses;
        public IEnumerable<User> Users => users;
        private IUoW unitOfWork = null;
        public ViewModel()
        {
            //We extract the connection string from the configuration JSON file.
            //We create a DbContextOption and pass it to the constructor.
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("MyDbConnection");

            var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionBuilder.UseSqlServer(connectionString).Options;
            unitOfWork = new UnitOfWork(options);
            //---------------------------------------------------------------------
            genres = new(unitOfWork.GenreRepo.Get());
            //Commands
            loadGenresCmd = new((o) => LoadGenres());


        }
        private readonly RelayCommand loadGenresCmd;
        public ICommand LoadGenresCmd => loadGenresCmd;
        public void LoadGenres()
        {
            genres = new( unitOfWork.GenreRepo.Get());
        }
    }
}
