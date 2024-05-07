using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.Domain;
using MongoDB.Bson;
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
    /// Interaction logic for AdminAjouterFilm.xaml
    /// </summary>
    public partial class AdminAjouterFilm : UserControl
    {
        private RepositoryFilms _repositoryFilms = new RepositoryFilms();

        public AdminAjouterFilm()
        {
            InitializeComponent();
            cbCategorie.ItemsSource = Enum.GetValues(typeof(EnumCategorie));
        }

        //private (string titre, string duree, DatePicker dateSortie, EnumCategorie categorie, 
        //    string acteurs, string realisateur, string directeur) GetContenuChamps()
        //{        
        //    return (txtTitre.Text.Trim(), txtDuree.Text.Trim(), dpDateSortie, (EnumCategorie)cbCategorie.SelectedItem, 
        //        txtActeurs.Text.Trim(), txtRealisateur.Text.Trim(), txtDirecteur.Text.Trim());
        //}

        private (string titre, string duree, DatePicker dateSortie, EnumCategorie categorie,
         List<Acteur> acteurs, List<Realisateur> realisateur, List<Directeur> directeur) GetContenuChamps()
        {
            string acteurs = txtActeurs.Text.Trim();
            string realisateur = txtRealisateur.Text.Trim();
            string directeur = txtDirecteur.Text.Trim();

            // Split the comma-separated strings into arrays
            string[] acteursArray = acteurs.Split(',');
            string[] realisateurArray = realisateur.Split(',');
            string[] directeurArray = directeur.Split(',');

            List<Acteur> acteursList = new List<Acteur>();
            List<Realisateur> realisateurList = new List<Realisateur>();
            List<Directeur> directeurList = new List<Directeur>();
            
            // Add each item in the arrays to the corresponding list
            foreach (string item in acteursArray)
            {
                acteursList.Add(new Acteur(item));
            }
            foreach (string item in realisateurArray)
            {
                realisateurList.Add(new Realisateur(item));
            }   
            foreach (string item in directeurArray)
            {
                directeurList.Add(new Directeur(item));
            }

            return (txtTitre.Text.Trim(), txtDuree.Text.Trim(), dpDateSortie, (EnumCategorie)cbCategorie.SelectedItem, acteursList, realisateurList, directeurList);
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var contenuChamps = GetContenuChamps();

                if (ValiderDonnees())
                {
                    Film film = new Film(ObjectId.GenerateNewId(),
                    contenuChamps.titre,
                    float.Parse(contenuChamps.duree),
                    contenuChamps.dateSortie.SelectedDate.Value,
                    contenuChamps.categorie,
                    contenuChamps.acteurs,
                    contenuChamps.realisateur,
                    contenuChamps.directeur,
                    new List<Abonne>());

                    _repositoryFilms.AddFilm(film);

                    MessageBox.Show("Film ajouté avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    ((MainWindow)Application.Current.MainWindow).AdminHomeControl();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de l'ajout du film" + ex.Message, "Erreur");
            }
        }

        private bool ValiderDonnees()
        {  
            var contenuChamps = GetContenuChamps();
            string messageErreur = "";

            if (contenuChamps.titre == "")
                messageErreur += "Veuillez remplir le champ titre\n";
            if (contenuChamps.duree == "")
                messageErreur += "Veuillez remplir le champ durée\n";
            if (contenuChamps.dateSortie.SelectedDate == null)
                messageErreur += "Veuillez remplir le champ date de sortie\n";
            if (contenuChamps.acteurs.Count == 0 || contenuChamps.acteurs == null)
                messageErreur += "Veuillez remplir le champ acteurs\n";
            if (contenuChamps.realisateur.Count == 0 || contenuChamps.realisateur == null)
                messageErreur += "Veuillez remplir le champ réalisateur\n";
            if (contenuChamps.directeur.Count == 0 || contenuChamps.directeur == null)
                messageErreur += "Veuillez remplir le champ directeur\n";
            if (contenuChamps.categorie == 0)
                messageErreur += "Veuillez choisir une catégorie\n";
            if (messageErreur.Trim().Length > 0)
            {
                MessageBox.Show(messageErreur, "Formulaire Ajout", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void txtDuree_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsControl((char)e.Key) && char.IsDigit((char)e.Key))
            {
                e.Handled = true;
            }
        }
    }
}
