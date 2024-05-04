using System.Collections.ObjectModel;
using CineQuebec.Windows.Domain;

namespace CineQuebec.Windows.DAL.Interfaces;

public interface IRepositorySalles
{
    public ReadOnlyCollection<Salle> LoadSalles();
}