using CineQuebec.Windows.View;
using System.Windows;

namespace CineQuebec.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainContentControl.Content = new ConnexionControl();
        }

        public void AdminHomeControl()
        {
            mainContentControl.Content = new AdminHomeControl();
        }

        public void AdminUsersControl()
        {
            mainContentControl.Content = new AdminAbonnesControl();
        }

        public void AdminHomeFilm()
        {
            mainContentControl.Content = new AdminHomeFilm();
        }

        public void AdminAjouterFilm()
        {
            mainContentControl.Content = new AdminAjouterFilm();
        }

        public void AbonneHomeControl()
        {
            mainContentControl.Content = new AbonneHomeControl();
        }
    }
}