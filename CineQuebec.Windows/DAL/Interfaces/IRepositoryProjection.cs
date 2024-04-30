using CineQuebec.Windows.Domain;

namespace CineQuebec.Windows.DAL.Interfaces;

public interface IRepositoryProjection
{
    public Projection AddProjection(Projection projection);
}