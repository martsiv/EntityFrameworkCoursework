using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data_access.Entities;
using PropertyChanged;
using static System.Reflection.Metadata.BlobBuilder;

namespace WpfClient.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        private ObservableCollection<Booking> bookings { get; set; }
        private ObservableCollection<CinemaHall> cinemaHalls { get; set; }
        private ObservableCollection<Film> films { get; set; }
        private ObservableCollection<MovieShow> movieShows { get; set; }
        private ObservableCollection<Rating> ratings { get; set; }
        private ObservableCollection<Ticket> tickets { get; set; }
        private ObservableCollection<TicketStatus> ticketStatuses { get; set; }
        private ObservableCollection<User> users { get; set; }
        public IEnumerable<Booking> Bookings => bookings;
        public IEnumerable<CinemaHall> CinemaHalls => cinemaHalls;
        public IEnumerable<Film> Films => films;
        public IEnumerable<MovieShow> MovieShows => movieShows;
        public IEnumerable<Rating> Ratings => ratings;
        public IEnumerable<Ticket> Tickets => tickets;
        public IEnumerable<TicketStatus> TicketStatuses => ticketStatuses;
        public IEnumerable<User> Users => users;
        private ViewModel()
        {
            
        }
    }
}
