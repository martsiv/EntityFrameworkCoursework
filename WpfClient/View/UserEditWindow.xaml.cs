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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public partial class UserEditWindow : Window
    {
        public User? MyUser { get; set; }
        public UserEditWindow(User user = null)
        {
            if (user != null)
                MyUser = user;
            else
                MyUser = new();
           
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

    }
}
