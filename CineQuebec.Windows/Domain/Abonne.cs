using MongoDB.Bson;

namespace CineQuebec.Windows.Domain
{
    public class Abonne : Entite, IAbonne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Username { get; set; }
        public string Courriel { get; set; }
        public byte[] MotDePasse { get; set; }
        public byte[] Salt { get; set; }
        public bool EstAdmin { get; init; } = false;
        public DateTime DateAdhesion { get; init; } = DateTime.Now;

        public Abonne(ObjectId id, string nom, string prenom, string username,
            string courriel, byte[] password, byte[] salt) : base(id)
        {
            Nom = nom;
            Prenom = prenom;
            Username = username;
            Courriel = courriel;
            MotDePasse = password;
            Salt = salt;
        }

        public Abonne() : base(ObjectId.Empty)
        {
        }

        public override string ToString()
        {
            return Prenom + " " + Nom + " - " + Username;
        }
    }
}
