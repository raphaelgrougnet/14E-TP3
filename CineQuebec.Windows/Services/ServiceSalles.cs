using System.Collections.ObjectModel;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services.Interfaces;

namespace CineQuebec.Windows.Services;

public class ServiceSalles : IServiceSalles
{
    private IRepositorySalles _repositorySalles;
    public ReadOnlyCollection<Salle> GetSalles()
    {
        return _repositorySalles.LoadSalles();
    }
    
    public ServiceSalles(IRepositorySalles repositorySalles)
    {
        _repositorySalles = repositorySalles;
    }
}