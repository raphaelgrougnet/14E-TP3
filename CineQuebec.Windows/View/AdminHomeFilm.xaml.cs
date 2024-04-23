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
using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.Domain;

namespace CineQuebec.Windows.View
{
    /// <summary>
    /// Interaction logic for AdminHomeFilm.xaml
    /// </summary>
    public partial class AdminHomeFilm : UserControl
    {
        private List<Film>? _films;

        private RepositoryFilms _repositoryFilms = new RepositoryFilms();

        private bool _estAffiche = true;

        public AdminHomeFilm()
        {
            InitializeComponent();
            _films = new List<Film>();
            AfficherListeFilms();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((MainWindow)Application.Current.MainWindow).AdminHomeControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors du retour vers la page Film" + ex.Message, "Erreur");
            }
        }

        private void AfficherListeFilms()
        {
            try
            {
                lstFilms.Items.Clear();

                _films = _repositoryFilms.LoadFilms();

                foreach (Film film in _films)
                    lstFilms.Items.Add(film);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de l'affichage des films" + ex.Message, "Erreur");
            }
        }

        private void AfficherListeFilmsAffiche()
        {
            try
            {
                lstFilms.Items.Clear();

                _films = _repositoryFilms.LoadFilmsAffiche();

                foreach (Film film in _films)
                    lstFilms.Items.Add(film);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de l'affichage des films à l'affiche" + ex.Message, "Erreur");
            } 
        }

        private void ChangerContenuListe()
        {
            if (_estAffiche)
                AfficherListeFilmsAffiche();
            else
                AfficherListeFilms();
        }

        private void ChangerAffichageBoutton()
        {
            if (_estAffiche)
                btnTri.Content = "Afficher la liste de tous films";
            else
                btnTri.Content = "Afficher liste des films à l'affiche";

            _estAffiche = !_estAffiche;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                ((MainWindow)Application.Current.MainWindow).AdminAjouterFilm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de l'ouverture de la page Formulaire d'Ajout" + ex.Message, "Erreur");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ChangerContenuListe();
            ChangerAffichageBoutton();
        }
    }
}
