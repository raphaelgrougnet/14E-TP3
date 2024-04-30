using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Domain;

namespace CineQuebec.Windows.DAL.Repositories;

public class RepositoryProjections : GenericRepository<Projection>, IRepositoryProjection
{
    public Projection AddProjection(IProjection projection)
    {
        throw new NotImplementedException();
    }
}