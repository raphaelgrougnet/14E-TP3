using CineQuebec.Windows.Domain;

namespace CineQuebec.Windows.DAL.Interfaces;

public interface IRepositoryProjections
{
    public Projection AddProjection(Projection projection);
}