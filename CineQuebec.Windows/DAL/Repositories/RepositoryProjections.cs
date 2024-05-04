using System.Collections.ObjectModel;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Domain;
using MongoDB.Driver;

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

    public ReadOnlyCollection<Projection> LoadProjections()
    {
        try
        {
            ReadOnlyCollection<Projection> projections = new ReadOnlyCollection<Projection>(Collection.Aggregate().ToList());
            return projections;
        }
        catch (Exception e)
        {
            throw new Exception("Erreur lors de la récupération des projections", e);
        }
    }
}