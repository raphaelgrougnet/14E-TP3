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
        private Abonne _abonne;

        private RepositoryAbonnes _repositoryAbonnes = new RepositoryAbonnes();

        private RepositoryActeur _repositoryActeur = new RepositoryActeur();

        private RepositoryRealisateur _repositoryRealisateur = new RepositoryRealisateur();

        private RepositoryDirecteur _repositoryDirecteur = new RepositoryDirecteur();

        private ServicePreferences _servicePreferences = new ServicePreferences();

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
            MessageBox.Show("Vous avez atteint le nombre maximum de préférences.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).AbonneMesPreferences(_abonne);
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            bool abonneAjouteNouvellePreference = false;
            if(AtLeastOneListIsSelected())
            {
                if (lstActeurs.SelectedItem != null)
                {
                    if(_servicePreferences.IsMaxPreferencesReached(_abonne.Preferences.Acteurs.Count))
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
                    if(_servicePreferences.IsMaxPreferencesReached(_abonne.Preferences.Realisateurs.Count))
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
                    if (_servicePreferences.IsMaxPreferencesReached(_abonne.Preferences.Directeurs.Count))
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
                    if(_servicePreferences.IsMaxPreferencesReached(_abonne.Preferences.Categories.Count))
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
                        AfficherMessageErreurMaxPreferencesReached();
                    }
                }

                if (abonneAjouteNouvellePreference)
                {
                    _repositoryAbonnes.UpdateAbonne(_abonne._id, _abonne.Preferences);
                    MessageBox.Show("Préférence ajoutée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    ((MainWindow)Application.Current.MainWindow).AbonneMesPreferences(_abonne);
                }
            }
            
        }

    }
}
