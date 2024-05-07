using System.Collections.ObjectModel;
using CineQuebec.Windows.Domain;
using MongoDB.Bson;

namespace CineQuebec.Windows.Services.Interfaces;

public interface IServiceAbonnes
{
    public ReadOnlyCollection<Abonne> GetAbonnes();
    public Abonne GetAbonneById(ObjectId id);
    public Abonne GetAbonneByUsername(string username);
    public bool UpdateAbonne(ObjectId id, Preference preference);

}