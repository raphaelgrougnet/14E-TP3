using MongoDB.Bson;

namespace CineQuebec.Windows.Domain
{
    public abstract class Entite
    {
        public ObjectId _id { get; init; }

        public Entite(ObjectId id)
        {
            _id = id;
        }


    }
}
