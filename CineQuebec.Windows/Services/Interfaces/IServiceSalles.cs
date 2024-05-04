using System.Collections.ObjectModel;
using CineQuebec.Windows.Domain;

namespace CineQuebec.Windows.Services.Interfaces;

public interface IServiceSalles
{
    public ReadOnlyCollection<Salle> GetSalles();
}