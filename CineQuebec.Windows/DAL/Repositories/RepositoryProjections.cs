using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Domain;

namespace CineQuebec.Windows.DAL.Repositories;

public class RepositoryProjections : GenericRepository<Projection>, IRepositoryProjections
{
    public Projection AddProjection(Projection projection)
    {
        try
        {
            Collection.InsertOne(projection);
            return projection;
        }
        catch (Exception e)
        {
            throw new Exception("Erreur lors de l'ajout de la projection", e);
        }
    }
}