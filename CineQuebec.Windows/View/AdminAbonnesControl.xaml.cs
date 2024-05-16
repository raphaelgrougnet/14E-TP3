using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.Services;

namespace CineQuebec.Windows.View
{
    /// <summary>
    /// Logique d'interaction pour AdminAbonnesControl.xaml
    /// </summary>
    public partial class AdminAbonnesControl : UserControl
    {
        private RepositoryAbonnes _repositoryAbonnes;
        private ServiceAbonnes _serviceAbonnes;

        public AdminAbonnesControl()
        {
            InitializeComponent();
            _repositoryAbonnes = new RepositoryAbonnes();
            _serviceAbonnes = new ServiceAbonnes(_repositoryAbonnes);
            ChargerAbonnes();
        }

        public void ChargerAbonnes()
        {
            try
            {
                
                ReadOnlyCollection<Abonne> abonnes = _serviceAbonnes.GetAbonnes();
                foreach (var abonne in abonnes)
                {
                    lstAbonnes.Items.Add(abonne);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors du chargement des abonnés" + ex.Message, "Erreur");
            } 
        }

        private void OffrirRecompense(Abonne abonne)
        {
            try
            {
                Abonne abonneSelectionne = abonne;
                MessageBoxResult reponse = MessageBox.Show("Voulez-vous offrir une récompense à cet abonné ?", 
                    "Récompense", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (reponse == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Félicitation vous avez offert une récompense à " + abonne.Nom + " " + abonne.Prenom, 
                        "Récompense", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de la distribution de la récompense" + ex.Message, "Erreur");
            }           
        }
        
        private void lstAbonnes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstAbonnes.SelectedIndex != -1)
            {
                OffrirRecompense(lstAbonnes.SelectedItem as Abonne);
            }
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).AdminHomeControl();
        }
    }
}
