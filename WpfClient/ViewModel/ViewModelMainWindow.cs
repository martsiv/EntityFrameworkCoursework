using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfClient.Help;
using WpfClient.View;

namespace WpfClient.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModelMainWindow
    {
        private AdminWindow adminWindow = null;
        private UserWindow userWindow = null;
        #region Commands to open general windows
        private readonly RelayCommand openAdminWindowCmd;
        private readonly RelayCommand openUserWindowCmd;
        public ICommand OpenAdminWindowCmd => openAdminWindowCmd;
        public ICommand OpenUserWindowCmd => openUserWindowCmd;
        public void OpenAdminWindow()
        {
            adminWindow = new AdminWindow();
            adminWindow.Closed += AdminWindow_Closed;
            adminWindow.Show();
        }
        public void OpenUserWindow()
        {
            userWindow = new UserWindow();
            userWindow.Closed += AdminWindow_Closed;
            userWindow.Show();
        }
        private void AdminWindow_Closed(object sender, EventArgs e)
        {
            adminWindow = null;
        }
        private bool CanOpenAdminWindow(object obj)
        {
            // Check if window is openes. If yes, this will returned false.
            return adminWindow == null || !adminWindow.IsVisible;
        }
        private void UserWindow_Closed(object sender, EventArgs e)
        {
            userWindow = null;
        }
        private bool CanOpenUserWindow(object obj)
        {
            // Check if window is openes. If yes, this will returned false.
            return userWindow == null || !userWindow.IsVisible;
        }
        #endregion Commands to open general windows
        public ViewModelMainWindow()
        {
            openAdminWindowCmd = new((o) => OpenAdminWindow(), CanOpenAdminWindow);
            openUserWindowCmd = new((o) => OpenUserWindow(), CanOpenUserWindow);
        }
    }
}
