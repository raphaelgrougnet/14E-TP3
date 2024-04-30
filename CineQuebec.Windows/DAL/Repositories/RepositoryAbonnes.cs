using System.Collections.ObjectModel;
using CineQuebec.Windows.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CineQuebec.Windows.DAL.Repositories
{
    public class RepositoryAbonnes : GenericRepository<Abonne>
    {
        public ReadOnlyCollection<Abonne> LoadAbonnes()
        {
            List<Abonne> abonnes = new List<Abonne>();

            try
            {
                abonnes = Collection.Aggregate().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection d'abonnés" + ex.Message, "Erreur");
            }
            return new ReadOnlyCollection<Abonne>(abonnes);
        }

        public Abonne FindAbonneById(ObjectId id)
        {
            Abonne abonne = null;

            try
            {
                abonne = Collection.Find(unAbonneParSonId => unAbonneParSonId._id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible de trouver l'abonné " + ex.Message, "Erreur");
            }
            return abonne;
        }

        public Abonne FindAbonneByUsername(string username)
        {
            Abonne abonne = null;

            try
            {
                abonne = Collection.Find(unAbonneParSonUsername => unAbonneParSonUsername.Username == username).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible de trouver l'abonné " + ex.Message, "Erreur");
            }
            return abonne;
        }

        
    }
}
