using CineQuebec.Windows.Domain;
using MongoDB.Driver;

namespace CineQuebec.Windows.DAL.Repositories
{
    public abstract class GenericRepository<TEntite> where TEntite : Entite
    {
        private IMongoClient mongoDBClient;
        private IMongoDatabase database;
        private const string NomDatabase = "TP3DB";
        private string NomCollection => typeof(TEntite).Name.ToLower() + "s";
        protected IMongoCollection<TEntite> Collection => database.GetCollection<TEntite>(NomCollection);

        protected GenericRepository(IMongoClient client = null)
        {
            mongoDBClient = client ?? OuvrirConnexion();
            database = ConnectDatabase();
        }
        private IMongoClient OuvrirConnexion()
        {
            MongoClient dbClient = null;
            try
            {
                dbClient = new MongoClient("mongodb://localhost:27017/");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible de se connecter à la base de données " + ex.Message, "Erreur");
            }
            return dbClient;
        }

        private IMongoDatabase ConnectDatabase()
        {
            IMongoDatabase db = null;
            try
            {
                db = mongoDBClient.GetDatabase(NomDatabase);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible de se connecter à la base de données " + ex.Message, "Erreur");
            }
            return db;
        }
    }
}
