using System.Collections;
using System.Collections.ObjectModel;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services.Interfaces;
using MongoDB.Bson;

namespace CineQuebec.Windows.Services;

public class ServiceProjections  : IServiceProjections
{
    private IRepositoryProjections _repositoryProjectionses;
    public ServiceProjections(IRepositoryProjections pRepositoryProjectionses)
    {
        _repositoryProjectionses = pRepositoryProjectionses;
    }

    public Projection ProgrammerReprojection(Film pFilm, Salle pSalle)
    {
        Projection projection = new Projection(ObjectId.GenerateNewId(), pSalle, DateTime.Now, pFilm);
        return _repositoryProjectionses.AddProjection(projection);
    }

    public ReadOnlyCollection<Projection> GetProjections()
    {
        return _repositoryProjectionses.LoadProjections();
    }

    public bool IsFilmEnSalle(Film film)
    {
        ReadOnlyCollection<Projection> projections = _repositoryProjectionses.LoadProjections();
        foreach (Projection projection in projections)
        {
            if (projection.Film._id == film._id)
            {
                return true;
            }
        }
        return false;
    }
}