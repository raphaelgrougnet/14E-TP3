using CineQuebec.Windows.Domain;

namespace CineQuebec.Windows.Services.Interfaces;

public interface IServiceSalles
{
    public List<Salle> GetSalles();
}