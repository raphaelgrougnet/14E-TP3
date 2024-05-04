using CineQuebec.Windows.Domain;

namespace CineQuebec.Windows.Services.Interfaces;

public interface IServiceProjections
{
    public Projection ProgrammerReprojection(Film pFilm, Salle pSalle);

}