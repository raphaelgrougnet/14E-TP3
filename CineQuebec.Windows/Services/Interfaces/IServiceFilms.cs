using CineQuebec.Windows.Domain;
using MongoDB.Bson;

namespace CineQuebec.Windows.Services.Interfaces;

public interface IServiceFilms
{
    public List<Film> GetFilms();
    public Film AddFilm(Film pFilm);
    public List<Film> LoadFilmsAffiche();
}