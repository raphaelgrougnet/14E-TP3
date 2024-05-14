using System.Windows;
using System.Windows.Controls;

namespace CineQuebec.Windows.View
{
    /// <summary>
    /// Logique d'interaction pour AdminHomeControl.xaml
    /// </summary>
    public partial class AdminHomeControl : UserControl
    {
        public AdminHomeControl()
        {
            InitializeComponent();
        }

        private void btnFilm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((MainWindow)Application.Current.MainWindow).AdminHomeFilm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de l'ouverture de la page Film" + ex.Message, "Erreur");
            }
        }

        private void btnUtilisateurs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((MainWindow)Application.Current.MainWindow).AdminUsersControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de l'ouverture de la page Abonnés" + ex.Message, "Erreur");
            }
        }

        private void btnRecompense_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((MainWindow)Application.Current.MainWindow).AdminHomeRecompenser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de l'ouverture de la page Récompense" + ex.Message, "Erreur");
            }
        }
    }
}
