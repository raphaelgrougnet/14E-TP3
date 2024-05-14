using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CineQuebec.Windows.View
{
    /// <summary>
    /// Interaction logic for AdminTicketAvantPremiere.xaml
    /// </summary>
    public partial class AdminTicketAvantPremiere : UserControl
    {
        private RepositoryAbonnes _repositoryAbonnes;
        private ServiceAbonnes _serviceAbonnes;

        private RepositoryFilms _repositoryFilms;
        private ServiceFilms _serviceFilms;

        private RepositoryRecompense _repositoryRecompense;
        private ServiceRecompense _serviceRecompense;
        public AdminTicketAvantPremiere()
        {
            InitializeComponent();
            _repositoryAbonnes = new RepositoryAbonnes();
            _serviceAbonnes = new ServiceAbonnes(_repositoryAbonnes);
            _repositoryFilms = new RepositoryFilms();
            _serviceFilms = new ServiceFilms(_repositoryFilms);
            _repositoryRecompense = new RepositoryRecompense();
            _serviceRecompense = new ServiceRecompense(_repositoryRecompense);
            GererbtnDonnerTicket();
            AfficherListeFilm();
        }

        private void GererbtnDonnerTicket()
        {
            if (cbFilm.SelectedItem == null || lstAbonnes.SelectedItem == null)
            {
                btnDonnerTicket.IsEnabled = false;
            }
            else
            {
                btnDonnerTicket.IsEnabled = true;
            }
        }

        private void AfficherListeFilm()
        {
            var films = _serviceFilms.LoadAllAvantPremiereFilm();
            cbFilm.ItemsSource = films;
        }

        private void AfficherListeAbonnes(List<Acteur> acteurs, List<Directeur> directeurs, List<Realisateur> realisateurs)
        {
            var abonnes = _serviceAbonnes.GetAbonnes();
            var abonnesAvecPreferences = new List<Abonne>(abonnes);

            abonnesAvecPreferences = abonnes.Where(a => a.Preferences.Acteurs.Any(acteur => acteurs.Any(a => a.Nom == acteur.Nom)) ||
                                                        a.Preferences.Directeurs.Any(directeur => directeurs.Any(d => d.Nom == directeur.Nom)) ||
                                                        a.Preferences.Realisateurs.Any(realisateur => realisateurs.Any(r => r.Nom == realisateur.Nom))).ToList();

            lstAbonnes.ItemsSource = abonnesAvecPreferences;
        }

        private void btnDonnerTicket_Click(object sender, RoutedEventArgs e)
        {
            if (lstAbonnes.SelectedItem != null && cbFilm.SelectedItem != null)
            {
                Abonne abonne = lstAbonnes.SelectedItem as Abonne;
                Film film = cbFilm.SelectedItem as Film;
                Recompense recompense = new Recompense($"Ticket Avant-Première pour {film.Titre}", EnumType.Invitation, "Merci de votre fidélité", abonne._id, film._id);
                _serviceRecompense.AddRecompenseToAbonne(recompense);

                MessageBox.Show("Le ticket a été donné à l'abonné", "Ticket donné", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void cbFilm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GererbtnDonnerTicket();
            if (cbFilm.SelectedItem != null)
            {
                var film = (Film)cbFilm.SelectedItem;
                AfficherListeAbonnes(film.Acteurs, film.Directeurs, film.Realisateurs);
            }
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).AdminHomeRecompenser();
        }

        private void lstAbonnes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GererbtnDonnerTicket();
        }
    }
}
