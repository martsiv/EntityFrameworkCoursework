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
        private IUoW unitOfWork = new UnitOfWork();
        public ViewModel()
        {
            loadGenresCmd = new((o) => LoadGenres());
            loadFilmsCmd = new((o) => LoadFilms());
        }
        private readonly RelayCommand loadGenresCmd;
        public ICommand LoadGenresCmd => loadGenresCmd;
        public void LoadGenres()
        {
            var res = unitOfWork.GenreRepo.Get();
            genres.Clear();
            foreach (var item in res) 
                genres.Add(item);
        }
        private readonly RelayCommand loadFilmsCmd;
        public ICommand LoadFilmsCmd => loadFilmsCmd;
        public void LoadFilms()
        {
            var res = unitOfWork.FilmRepo.Get(includeProperties: "Genre,Rating");
            films.Clear();
            foreach (var item in res)
                films.Add(item);
        }
    }
}
