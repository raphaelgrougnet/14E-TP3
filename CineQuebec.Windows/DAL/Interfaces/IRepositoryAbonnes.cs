using CineQuebec.Windows.Domain;
using MongoDB.Bson;
using System.Collections.ObjectModel;

namespace CineQuebec.Windows.DAL.Interfaces;

public interface IRepositoryAbonnes
{
    public ReadOnlyCollection<Abonne> LoadAbonnes();
    public Abonne FindAbonneById(ObjectId id);

    public Abonne FindAbonneByUsername(string username);
    public bool UpdateAbonne(ObjectId id, Preference preference);

}