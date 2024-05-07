using System.Collections.ObjectModel;
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
        _filmsVisionnes = new ReadOnlyCollection<Film>(new List<Film>());
        ChargerListeFilmsVisionnes();
    }
    
    private void ChargerListeFilmsVisionnes()
    {
        _filmsVisionnes = _serviceFilms.GetFilmsVisionnes(_abonne);
        lstFilms.ItemsSource = _filmsVisionnes;
    }
}