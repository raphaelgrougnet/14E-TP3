using CineQuebec.Windows.Domain;
using CineQuebec.Windows.View;
using System.Windows;
using CineQuebec.Windows.Domain;

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

        public void AdminHomeRecompenser()
        {
            mainContentControl.Content = new AdminHomeRecompenser();
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
        
        public void AbonneFilmsVisionnesControl(Abonne abonne)
        {
            mainContentControl.Content = new AbonneFilmsVisonnesControl(abonne);
        }

        public void AbonneHomeControl(Abonne abonne)
        {
            mainContentControl.Content = new AbonneHomeControl(abonne);
        }

        public void AbonneMesPreferences(Abonne abonne)
        {
            mainContentControl.Content = new AbonneMesPreferences(abonne);
        }

        public void AbonneAjouterPreference(Abonne abonne)
        {
            mainContentControl.Content = new AbonneAjouterPreference(abonne);
        }
    }
}