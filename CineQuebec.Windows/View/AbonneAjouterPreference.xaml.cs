using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.Domain;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AbonneAjouterPreference.xaml
    /// </summary>
    public partial class AbonneAjouterPreference : UserControl
    {
        private Abonne _abonne;

        private RepositoryAbonnes _repositoryAbonnes = new RepositoryAbonnes();

        private RepositoryActeur _repositoryActeur = new RepositoryActeur();

        private RepositoryRealisateur _repositoryRealisateur = new RepositoryRealisateur();

        private RepositoryDirecteur _repositoryDirecteur = new RepositoryDirecteur();

        public AbonneAjouterPreference(Abonne abonne)
        {
            InitializeComponent();
            _abonne = abonne;
            AfficherLesListes();
        }

        private void AfficherLesListes()
        {
            lstActeurs.Items.Clear();
            lstRealisateurs.Items.Clear();
            lstDirecteurs.Items.Clear();
            lstCategories.Items.Clear();

            ReadOnlyCollection<Acteur> acteurs = _repositoryActeur.LoadActeurs();
            ReadOnlyCollection<Realisateur> realisateurs = _repositoryRealisateur.LoadRealisateurs();
            ReadOnlyCollection<Directeur> directeurs = _repositoryDirecteur.LoadDirecteurs();

            lstActeurs.ItemsSource = acteurs;
            lstRealisateurs.ItemsSource = realisateurs;
            lstDirecteurs.ItemsSource = directeurs;
            lstCategories.ItemsSource = Enum.GetValues(typeof(EnumCategorie));
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).AbonneMesPreferences(_abonne);
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            bool abonneAjouteNouvellePreference = false;
            if(lstActeurs.SelectedItem != null)
            {
                Acteur acteur = (Acteur)lstActeurs.SelectedItem;
                _abonne.AjouterActeur(acteur);
                abonneAjouteNouvellePreference = true;
            }
            if (lstRealisateurs.SelectedItem != null)
            {
                Realisateur realisateur = (Realisateur)lstRealisateurs.SelectedItem;
                _abonne.AjouterRealisateur(realisateur);
                abonneAjouteNouvellePreference = true;
            }
            if (lstDirecteurs.SelectedItem != null)
            {
                Directeur directeur = (Directeur)lstDirecteurs.SelectedItem;
                _abonne.AjouterDirecteur(directeur);
                abonneAjouteNouvellePreference = true;
            }
            if (lstCategories.SelectedItem != null)
            {
                EnumCategorie categorie = (EnumCategorie)lstCategories.SelectedItem;
                _abonne.AjouterCategorie(categorie);
                abonneAjouteNouvellePreference = true;
            }

            if(abonneAjouteNouvellePreference)
            {
                _repositoryAbonnes.UpdateAbonne(_abonne._id, _abonne.Preferences);
                MessageBox.Show("Préférence ajoutée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                ((MainWindow)Application.Current.MainWindow).AbonneMesPreferences(_abonne);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une préférence à ajouter.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
