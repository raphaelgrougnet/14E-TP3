using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services;
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
        public const int MAX_PREFERENCES = 5;

        public const int MAX_PREFERENCES_CATEGORIES = 3;

        private Abonne _abonne;

        private RepositoryAbonnes _repositoryAbonnes;
        private ServiceAbonnes _serviceAbonnes;

        private RepositoryActeur _repositoryActeur;
        private ServiceActeur _serviceActeur;

        private RepositoryRealisateur _repositoryRealisateur;
        private ServiceRealisateur _serviceRealisateur;

        private RepositoryDirecteur _repositoryDirecteur;
        private ServiceDirecteur _serviceDirecteur;

        private ServicePreferences _servicePreferences;


        public AbonneAjouterPreference(Abonne abonne)
        {
            InitializeComponent();
            _abonne = abonne;
            _repositoryAbonnes = new RepositoryAbonnes();
            _serviceAbonnes = new ServiceAbonnes(_repositoryAbonnes);
            _repositoryActeur = new RepositoryActeur();
            _serviceActeur = new ServiceActeur(_repositoryActeur);
            _repositoryRealisateur = new RepositoryRealisateur();
            _serviceRealisateur = new ServiceRealisateur(_repositoryRealisateur);
            _repositoryDirecteur = new RepositoryDirecteur();
            _serviceDirecteur = new ServiceDirecteur(_repositoryDirecteur);
            _servicePreferences = new ServicePreferences();
            AfficherLesListes();
        }

        private void AfficherLesListes()
        {
            lstActeurs.Items.Clear();
            lstRealisateurs.Items.Clear();
            lstDirecteurs.Items.Clear();
            lstCategories.Items.Clear();

            ReadOnlyCollection<Acteur> acteurs = _serviceActeur.LoadActeurs();
            ReadOnlyCollection<Realisateur> realisateurs = _serviceRealisateur.LoadRealisateurs();
            ReadOnlyCollection<Directeur> directeurs = _serviceDirecteur.LoadDirecteurs();

            lstActeurs.ItemsSource = acteurs;
            lstRealisateurs.ItemsSource = realisateurs;
            lstDirecteurs.ItemsSource = directeurs;
            lstCategories.ItemsSource = Enum.GetValues(typeof(EnumCategorie));
        }

        private bool AtLeastOneListIsSelected()
        {
            if(lstActeurs.SelectedItem == null && lstRealisateurs.SelectedItem == null && lstDirecteurs.SelectedItem == null && lstCategories.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner au moins un élément.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void AfficherMessageErreurIsAlreadyInList(string type)
        {
            MessageBox.Show(type + " est déjà dans la liste des préférences.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AfficherMessageErreurMaxPreferencesReached()
        {
            MessageBox.Show($"Vous avez atteint le nombre maximum de préférences ({MAX_PREFERENCES}).", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AfficherMessageErreurMaxCategoriePreferencesReached()
        {
            MessageBox.Show($"Vous avez atteint le nombre maximum de catégories ({MAX_PREFERENCES_CATEGORIES}).", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).AbonneMesPreferences(_abonne);
        }

        private void DeselectionnerTout()
        {
            lstActeurs.SelectedItem = null;
            lstRealisateurs.SelectedItem = null;
            lstDirecteurs.SelectedItem = null;
            lstCategories.SelectedItem = null;
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            bool abonneAjouteNouvellePreference = false;
            if(AtLeastOneListIsSelected())
            {
                if (lstActeurs.SelectedItem != null)
                {
                    if(_servicePreferences.IsMaxPreferencesReached(_abonne.Preferences.Acteurs.Count, MAX_PREFERENCES))
                    {
                        Acteur acteur = (Acteur)lstActeurs.SelectedItem;
                        if (_servicePreferences.IsAlreadyInList(_abonne.Preferences.Acteurs, acteur) == false)
                        {
                            _abonne.AjouterActeur(acteur);
                            abonneAjouteNouvellePreference = true;
                        }
                        else
                        {
                            AfficherMessageErreurIsAlreadyInList("Cet acteur");
                        }
                    }
                }
                if (lstRealisateurs.SelectedItem != null)
                {
                    if(_servicePreferences.IsMaxPreferencesReached(_abonne.Preferences.Realisateurs.Count, MAX_PREFERENCES))
                    {
                        Realisateur realisateur = (Realisateur)lstRealisateurs.SelectedItem;
                        if (_servicePreferences.IsAlreadyInList(_abonne.Preferences.Realisateurs, realisateur) == false)
                        {
                            _abonne.AjouterRealisateur(realisateur);
                            abonneAjouteNouvellePreference = true;
                        }
                        else
                        {
                            AfficherMessageErreurIsAlreadyInList("Ce réalisateur");
                        }
                    }
                    else
                    {
                        AfficherMessageErreurMaxPreferencesReached();
                    }                   
                }
                if (lstDirecteurs.SelectedItem != null)
                {
                    if (_servicePreferences.IsMaxPreferencesReached(_abonne.Preferences.Directeurs.Count, MAX_PREFERENCES))
                    {
                        Directeur directeur = (Directeur)lstDirecteurs.SelectedItem;
                        if (_servicePreferences.IsAlreadyInList(_abonne.Preferences.Directeurs, directeur) == false)
                        {
                            _abonne.AjouterDirecteur(directeur);
                            abonneAjouteNouvellePreference = true;
                        }
                        else
                        {
                            AfficherMessageErreurIsAlreadyInList("Ce directeur");
                        }
                    }
                    else
                    {
                        AfficherMessageErreurMaxPreferencesReached();
                    }                  
                }
                if (lstCategories.SelectedItem != null)
                {
                    if(_servicePreferences.IsMaxCategoriePreferencesReached(_abonne.Preferences.Categories.Count, MAX_PREFERENCES_CATEGORIES))
                    {
                        EnumCategorie categorie = (EnumCategorie)lstCategories.SelectedItem;
                        if (_servicePreferences.CategorieIsInList(_abonne.Preferences.Categories, categorie) == false)
                        {
                            _abonne.AjouterCategorie(categorie);
                            abonneAjouteNouvellePreference = true;
                        }
                        else
                        {
                            AfficherMessageErreurIsAlreadyInList("Cette catégorie");
                        }
                    }
                    else
                    {
                        AfficherMessageErreurMaxCategoriePreferencesReached();
                    }
                }
                DeselectionnerTout();
                if (abonneAjouteNouvellePreference)
                {
                    _serviceAbonnes.UpdateAbonne(_abonne._id, _abonne.Preferences);
                    MessageBox.Show("Préférence ajoutée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    ((MainWindow)Application.Current.MainWindow).AbonneMesPreferences(_abonne);
                }
            }
            
        }

        private void btnDeselectionner_Click(object sender, RoutedEventArgs e)
        {
            DeselectionnerTout();
        }
    }
}
