using data_access.Entities;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfClient.View
{
    /// <summary>
    /// Interaction logic for FilmWindow.xaml
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public partial class FilmEditWindow : Window
    {
        public Film? MyFilm { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }
        public FilmEditWindow(List<Genre> genres = null, Film film = null)
        {
            if (film != null)
                MyFilm = film;
            else
                MyFilm = new();
            if (genres != null)
            {
                Genres = new();
                foreach (var genre in genres)
                    Genres.Add(genre);
            }
            else
                Genres = null;
            InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void FilmGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Genre selectedGenre = (Genre)FilmGenre.SelectedItem;

            if (selectedGenre != null)
            {
                MyFilm.Genre = selectedGenre;
                MyFilm.GenreId = selectedGenre.Id;
            }
            //As alternative we can use "sender"
            //if (sender is ComboBox comboBox)
            //{
            //    // Отримуємо обраний об'єкт Genre з ComboBox
            //    Genre selectedGenre = (Genre)comboBox.SelectedItem;
            //}
        }
    }
}
