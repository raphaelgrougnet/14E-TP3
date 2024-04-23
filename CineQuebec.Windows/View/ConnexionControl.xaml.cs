using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services;
using System.Windows;
using System.Windows.Controls;

namespace CineQuebec.Windows.View
{
    /// <summary>
    /// Logique d'interaction pour ConnexionControl.xaml
    /// </summary>
    public partial class ConnexionControl : UserControl
    {
        private RepositoryAbonnes _repositoryAbonnes = new RepositoryAbonnes();

        public ConnexionControl()
        {
            InitializeComponent();
        }

        private (string username, string password) GetContenuChampsConnexion()
        {
            return (txtUsername.Text.Trim(), txtPassword.Text.Trim());
        }

        private bool ValiderChamps()
        {
            string messageErreur = "";

            if (txtUsername.Text.Trim() == "")
                messageErreur += "Veuillez remplir le champ nom d'utilisateur\n";

            if (txtPassword.Text.Trim() == "")
                messageErreur += "Veuillez remplir le champ mot de passe\n";

            if (messageErreur.Trim().Length > 0)
            {
                MessageBox.Show(messageErreur, "Connexion", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }


        private Abonne? TesterConnexion(string username, string motDePasseSaisi)
        {
            try
            {
                Abonne abonneTrouve = _repositoryAbonnes.FindAbonneByUsername(username);

                if (abonneTrouve == null || !abonneTrouve.EstMotDePasseCorrespond(motDePasseSaisi))
                {
                    MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect", "Connexion", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    return null;
                }
                return abonneTrouve;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors du test de la connexion" + ex.Message, "Erreur");
            }
            return null;
        }

        private bool TesterEstAdmin(Abonne abonne)
        {
            if (!abonne.EstAdmin)
            {
                MessageBox.Show("Vous n'êtes pas administrateur, vous ne pouvez pas accéder à l'interface", "Connexion", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (string username, string password) valeursChampsConnexion = GetContenuChampsConnexion();

                if (!ValiderChamps())
                    return;

                Abonne? abonne = TesterConnexion(valeursChampsConnexion.username, valeursChampsConnexion.password);

                if (abonne == null)
                    return;

                if (!TesterEstAdmin(abonne))
                    return;


                ((MainWindow)Application.Current.MainWindow).AdminHomeControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de la connexion" + ex.Message, "Erreur");
            }
        }
    }
}
