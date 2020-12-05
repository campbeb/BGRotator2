using System;
using System.Linq;
using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;

namespace BGRotator2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon TrayIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // TRAY ICON
            TrayIcon = (TaskbarIcon)FindResource("TrayIcon");

            if (BGRotator2.Properties.Settings.Default.settingsUpgradeRequired)
            {
                BGRotator2.Properties.Settings.Default.Upgrade();
                BGRotator2.Properties.Settings.Default.settingsUpgradeRequired = false;
                BGRotator2.Properties.Settings.Default.Save();
            }
        }

        public MainWindow GetMainWindow
        {
            get
            {
                return Windows.OfType<MainWindow>().FirstOrDefault();
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            GetMainWindow.DisplayWindow();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Shutdown();
        }

        private void Favorite_Click(object sender, EventArgs e)
        {
            GetMainWindow.FavoriteWallpaper();
        }

        private void Trash_Click(object sender, EventArgs e)
        {
            GetMainWindow.TrashWallpaper();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            GetMainWindow.NextWallpaper();
        }
    }
}
