using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.DAL.Repositories;

namespace CineQuebec.Windows.View
{
    /// <summary>
    /// Logique d'interaction pour AdminAbonnesControl.xaml
    /// </summary>
    public partial class AdminAbonnesControl : UserControl
    {
        RepositoryAbonnes _repositoryAbonnes = new RepositoryAbonnes();
        public AdminAbonnesControl()
        {
            InitializeComponent();
            ChargerAbonnes();
        }

        public void ChargerAbonnes()
        {
            try
            {
                
                List<Abonne> abonnes = _repositoryAbonnes.LoadAbonnes();
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

        private void btnFermer_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ((MainWindow)Application.Current.MainWindow).AdminHomeControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de la fermeture de la page" + ex.Message, "Erreur");
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
    }
}
