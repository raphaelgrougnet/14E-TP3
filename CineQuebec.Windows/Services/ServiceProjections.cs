using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services.Interfaces;

namespace CineQuebec.Windows.Services;

public class ServiceProjections  : IServiceProjections
{
    private IRepositoryProjection _repositoryProjections;
    public ServiceProjections(IRepositoryProjection pRepositoryProjections)
    {
        _repositoryProjections = pRepositoryProjections;
    }

    public Projection ProgrammerReprojection(Projection pProjection)
    {
        return _repositoryProjections.AddProjection(pProjection);
    }
}