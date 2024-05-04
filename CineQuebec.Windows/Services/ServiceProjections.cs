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
        Projection projection = new Projection(ObjectId.GenerateNewId(), pSalle.Nom, DateTime.Now, pFilm);
        return _repositoryProjectionses.AddProjection(projection);
    }
}