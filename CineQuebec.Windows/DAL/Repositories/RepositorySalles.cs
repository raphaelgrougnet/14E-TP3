using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Domain;
using MongoDB.Driver;

namespace CineQuebec.Windows.DAL.Repositories;

public class RepositorySalles : GenericRepository<Salle>, IRepositorySalles
{
    public List<Salle> LoadSalles()
    {
        List<Salle> salles = new List<Salle>();
        try
        {
            salles = Collection.Aggregate().ToList();
            return salles;
        }
        catch (Exception e)
        {
            throw new Exception("Erreur lors de la récupération des salles", e);
        }
    }
}