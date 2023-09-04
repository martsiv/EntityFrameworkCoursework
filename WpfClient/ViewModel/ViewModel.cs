using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;
using data_access.Data;
using data_access.Entities;
using data_access.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PropertyChanged;
using WpfClient.Help;
using WpfClient.View;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.VisualBasic;

namespace WpfClient.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        //Collections
        #region Collections
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
        #endregion
        //UoF
        private IUoW unitOfWork = new UnitOfWork();
        public ViewModel()
        {
            loadBookingsCmd = new((o) => LoadBookings());
            loadCinemaHallsCmd = new((o) => LoadCinemaHalls());
            loadFilmsCmd = new((o) => LoadFilms());
            loadGenresCmd = new((o) => LoadGenres());
            loadMoviewShowsCmd = new((o) => LoadMovieShows());
            loadRatingsCmd = new((o) => LoadRatings());
            loadTicketsCmd = new((o) => LoadTickets());
            loadTicketStatusesCmd = new((o) => LoadTicketStatuses());
            loadUsersCmd = new((o) => LoadUsers());

            addFilmCmd = new((o) => AddFilm());
            editFilmCmd = new((o) => EditFilm(o));

            LoadCinemaHalls();
            LoadGenres();
            LoadTicketStatuses();
        }
        //Commands
        //Load collections
        #region Load collections
        private readonly RelayCommand loadBookingsCmd;
        private readonly RelayCommand loadCinemaHallsCmd;
        private readonly RelayCommand loadFilmsCmd;
        private readonly RelayCommand loadGenresCmd;
        private readonly RelayCommand loadMoviewShowsCmd;
        private readonly RelayCommand loadRatingsCmd;
        private readonly RelayCommand loadTicketsCmd;
        private readonly RelayCommand loadTicketStatusesCmd;
        private readonly RelayCommand loadUsersCmd;
        public ICommand LoadBookingsCmd => loadBookingsCmd;
        public ICommand LoadCinemaHallsCmd => loadCinemaHallsCmd;
        public ICommand LoadGenresCmd => loadGenresCmd;
        public ICommand LoadFilmsCmd => loadFilmsCmd;
        public ICommand LoadMoviewShowsCmd => loadMoviewShowsCmd;
        public ICommand LoadRatingsCmd => loadRatingsCmd;
        public ICommand LoadTicketsCmd => loadTicketsCmd;
        public ICommand LoadTicketStatusesCmd => loadTicketStatusesCmd;
        public ICommand LoadUsersCmd => loadUsersCmd;
        public void LoadBookings()
        {
            var res = unitOfWork.BookingRepo.Get();
            bookings.Clear();
            foreach (var item in res)
                bookings.Add(item);
        }
        public void LoadCinemaHalls()
        {
            var res = unitOfWork.CinemaHallRepo.Get();
            cinemaHalls.Clear();
            foreach (var item in res)
                cinemaHalls.Add(item);
        }
        public void LoadGenres()
        {
            var res = unitOfWork.GenreRepo.Get();
            genres.Clear();
            foreach (var item in res)
                genres.Add(item);
        }
        public void LoadFilms()
        {
            var res = unitOfWork.FilmRepo.Get(includeProperties: "Genre,Rating");
            films.Clear();
            foreach (var item in res)
                films.Add(item);
        }
        public void LoadMovieShows()
        {
            var res = unitOfWork.MovieShowRepo.Get();
            movieShows.Clear();
            foreach (var item in res)
                movieShows.Add(item);
        }
        public void LoadRatings()
        {
            var res = unitOfWork.RatingRepo.Get();
            ratings.Clear();
            foreach (var item in res)
                ratings.Add(item);
        }
        public void LoadTickets()
        {
            var res = unitOfWork.TicketRepo.Get();
            tickets.Clear();
            foreach (var item in res)
                tickets.Add(item);
        }
        public void LoadTicketStatuses()
        {
            var res = unitOfWork.TicketStatusRepo.Get();
            ticketStatuses.Clear();
            foreach (var item in res)
                ticketStatuses.Add(item);
        }
        public void LoadUsers()
        {
            var res = unitOfWork.UserRepo.Get();
            users.Clear();
            foreach (var item in res)
                users.Add(item);
        }
        #endregion  Load collections

        #region Admin menu
        private readonly RelayCommand addFilmCmd;
        private readonly RelayCommand editFilmCmd;

        public ICommand AddFilmCmd => addFilmCmd;
        public ICommand EditFilmCmd => editFilmCmd;
        public void AddFilm()
        {
            FilmWindow filmWindow = new FilmWindow(Genres.ToList(), new Film());
            if (filmWindow.DialogResult == true)
            {
                Film? newFilm = filmWindow.MyFilm;
                if (newFilm == null) return;
                //films.Add(newFilm);
                unitOfWork.FilmRepo.Insert(newFilm);
                unitOfWork.Save();
                LoadFilms();
            }
        }
        public void EditFilm(object selectedFilm)
        {
            Film? film = selectedFilm as Film;
            if (film == null) return;

            Film vm = new Film
            {
                Id = film.Id,
                Name = film.Name,
                Description = film.Description,
                Director = film.Director,
                Duration = film.Duration,
                Rating = film.Rating,
                Year = film.Year,
                GenreId = film.GenreId,
                Genre = film.Genre,
                MovieShows = film.MovieShows,
            };
            FilmWindow filmWindow = new FilmWindow(Genres.ToList(), vm);


            if (filmWindow.ShowDialog() == true)
            {
                film.Name = filmWindow.MyFilm.Name;
                film.Description = filmWindow.MyFilm.Description; 
                film.Director = filmWindow.MyFilm.Director; 
                film.Duration = filmWindow.MyFilm.Duration;
                film.Rating = filmWindow.MyFilm.Rating;
                film.Year = filmWindow.MyFilm.Year;
                film.GenreId = filmWindow.MyFilm.GenreId;
                unitOfWork.FilmRepo.Update(film);
                unitOfWork.Save();
                LoadFilms();
            }
        }
        #endregion Admin menu
    }
}
