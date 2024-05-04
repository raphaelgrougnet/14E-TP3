using CineQuebec.Windows.Domain;

namespace CineQuebec.Windows.DAL.Interfaces;

public interface IRepositorySalles
{
    public List<Salle> LoadSalles();
}