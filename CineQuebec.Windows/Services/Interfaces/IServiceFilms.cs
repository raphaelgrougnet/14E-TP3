using System.Collections.ObjectModel;
using CineQuebec.Windows.Domain;
using MongoDB.Bson;

namespace CineQuebec.Windows.Services.Interfaces;

public interface IServiceFilms
{
    public ReadOnlyCollection<Film> GetFilms();
    public Film AddFilm(Film pFilm);
    public ReadOnlyCollection<Film> LoadFilmsAffiche();
    public Film UpdateFilm(Film pFilm);
}