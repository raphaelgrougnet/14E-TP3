using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services;
using MongoDB.Bson;

namespace CineQuebec.Windows.View;

public partial class AdminReprojeterFilm : Window
{
    private Film _film;
    private RepositoryProjections _repositoryProjections;
    private ServiceProjections _serviceProjections;
    
    private ReadOnlyCollection<Salle> _salles;
    private RepositorySalles _repositorySalles;
    private ServiceSalles _serviceSalles;
    
    private Salle _salleSelectionnee;
    public AdminReprojeterFilm(Film pFilm)
    {
        InitializeComponent();
        
        _repositoryProjections = new RepositoryProjections();
        _serviceProjections = new ServiceProjections(_repositoryProjections);
        
        _repositorySalles = new RepositorySalles();
        _serviceSalles = new ServiceSalles(_repositorySalles);
        
        _film = pFilm;
        
        
        ChargerDetailsFilm(_film);
        
        ChargerListeSalles();
        
        
    }


    private void ChargerListeSalles()
    {
        _salles = _serviceSalles.GetSalles();
        cboSalles.ItemsSource = _salles;
        if (_salles.Count > 0) cboSalles.SelectedIndex = 0;
    }
    
    private void ChangerAffichageEnSalle()
    {
        if (_serviceProjections.IsFilmEnSalle(_film))
        {
            txtEnSalleFilm.Text = "Le film est actuellement en salle.";
            btnReprojeter.IsEnabled = false;
        }
        else
        {
            txtEnSalleFilm.Text = "Le film n'est pas actuellement en salle.";
            btnReprojeter.IsEnabled = true;
        }
    }

    private void ChargerDetailsFilm(Film pFilm)
    {
        txtFilm.Text = pFilm.Titre;
        txtDureeFilm.Text = "Durée : " + pFilm.Duree + " minutes";
        txtSortieFilm.Text = "Date de sortie : " + pFilm.DateSortie.ToString("dd/MM/yyyy");
        ChangerAffichageEnSalle();
    }
    
    
    
    private void BtnReprojeter_OnClick(object sender, RoutedEventArgs e)
    {
        if (cboSalles.SelectedItem == null)
        {
            MessageBox.Show("Veuillez sélectionner une salle.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        MessageBoxResult messageBoxResult = MessageBox.Show("Etes-vous sûr de vouloir reprojeter le film dans " + _salleSelectionnee + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (messageBoxResult == MessageBoxResult.Yes)
        {
            
            _serviceProjections.ProgrammerReprojection(_film, _salleSelectionnee);
            MessageBox.Show("Le film a été reprojeté avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }

    private void BtnAnnuler_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBoxResult messageBoxResult = MessageBox.Show("Etes-vous sûr de vouloir annuler la reprojection ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (messageBoxResult == MessageBoxResult.Yes){ Close();}
    }

    private void CboSalles_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cboSalles.SelectedItem != null) _salleSelectionnee = (Salle) cboSalles.SelectedItem;
    }
}