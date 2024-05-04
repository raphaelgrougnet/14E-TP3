using System.Collections.ObjectModel;
using CineQuebec.Windows.Domain;

namespace CineQuebec.Windows.Services.Interfaces;

public interface IServiceProjections
{
    public Projection ProgrammerReprojection(Film pFilm, Salle pSalle);
    public ReadOnlyCollection<Projection> GetProjections();
    public bool IsFilmEnSalle(Film film);

}