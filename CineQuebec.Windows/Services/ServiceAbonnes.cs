using System.Collections.ObjectModel;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services.Interfaces;
using MongoDB.Bson;

namespace CineQuebec.Windows.Services;

public class ServiceAbonnes : IServiceAbonnes
{
    
    private IRepositoryAbonnes _repositoryAbonnes;
    
    public ServiceAbonnes(IRepositoryAbonnes repositoryAbonnes)
    {
        _repositoryAbonnes = repositoryAbonnes;
    }
    
    public ReadOnlyCollection<Abonne> GetAbonnes()
    {
        return _repositoryAbonnes.LoadAbonnes();
    }

    public Abonne GetAbonneById(ObjectId id)
    {
        return _repositoryAbonnes.FindAbonneById(id);
    }

    public Abonne GetAbonneByUsername(string username)
    {
        return _repositoryAbonnes.FindAbonneByUsername(username);
    }
}