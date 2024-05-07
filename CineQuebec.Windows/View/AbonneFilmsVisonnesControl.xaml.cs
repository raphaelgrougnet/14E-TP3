using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services;

namespace CineQuebec.Windows.View;

public partial class AbonneFilmsVisonnesControl : UserControl
{
    private RepositoryFilmNotes _repositoryFilmNotes;
    private ServiceFilmNotes _serviceFilmNotes;
    private RepositoryFilms _repositoryFilms;
    private ServiceFilms _serviceFilms;
    private Abonne _abonne;
    private ReadOnlyCollection<Film> _filmsVisionnes;
    
    public AbonneFilmsVisonnesControl(Abonne pAbonne)
    {
        InitializeComponent();
        _repositoryFilmNotes = new RepositoryFilmNotes();
        _serviceFilmNotes = new ServiceFilmNotes(_repositoryFilmNotes);
        _repositoryFilms = new RepositoryFilms();
        _serviceFilms = new ServiceFilms(_repositoryFilms);
        _abonne = pAbonne;
        ChargerListeFilmsVisionnes();
    }
    
    private void ChargerListeFilmsVisionnes()
    {
        _filmsVisionnes = new ReadOnlyCollection<Film>(_abonne.FilmsVisionnes);
        lstFilms.ItemsSource = _filmsVisionnes;
    }


    private void BtnRetour_OnClick(object sender, RoutedEventArgs e)
    {
        ((MainWindow)Application.Current.MainWindow).AbonneHomeControl(_abonne);
    }
}