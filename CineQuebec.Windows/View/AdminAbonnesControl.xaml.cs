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

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).AdminHomeControl();
        }
    }
}
