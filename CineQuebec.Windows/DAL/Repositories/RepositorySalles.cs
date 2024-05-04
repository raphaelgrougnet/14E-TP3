using System.Collections.ObjectModel;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Domain;
using MongoDB.Driver;

namespace CineQuebec.Windows.DAL.Repositories;

public class RepositorySalles : GenericRepository<Salle>, IRepositorySalles
{
    public ReadOnlyCollection<Salle> LoadSalles()
    {
        try
        {
            ReadOnlyCollection<Salle> salles = new ReadOnlyCollection<Salle>(Collection.Aggregate().ToList());
            return salles;
        }
        catch (Exception e)
        {
            throw new Exception("Erreur lors de la récupération des salles", e);
        }
    }
}