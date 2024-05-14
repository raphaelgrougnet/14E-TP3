using System.Collections.ObjectModel;
using CineQuebec.Windows.Domain;

namespace CineQuebec.Windows.DAL.Interfaces;

public interface IRepositoryFilms
{
    public ReadOnlyCollection<Film> LoadFilms();
    public Film AddFilm(Film film);
    public ReadOnlyCollection<Film> LoadFilmsAffiche();
    public Film UpdateFilm(Film film);
    public ReadOnlyCollection<Film> LoadAllAvantPremiereFilm();
    public bool DeleteFilm(Film film);
}