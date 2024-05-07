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
        public Preference Preferences { get; set; }
        public List<Film> FilmsVisionnes { get; set; } = new List<Film>();
        

        public Abonne(ObjectId id, string nom, string prenom, string username,
            string courriel, byte[] password, byte[] salt, Preference preferences, List<Film> filmsVisonnes, List<Film> filmsVisionnes) : base(id)
        {
            Nom = nom;
            Prenom = prenom;
            Username = username;
            Courriel = courriel;
            MotDePasse = password;
            Salt = salt;
            Preferences = preferences;
            FilmsVisionnes = filmsVisonnes;
        }

        public Abonne() : base(ObjectId.Empty)
        {
        }

        public void AjouterActeur(Acteur acteur)
        {
            Preferences.Acteurs.Add(acteur);
        }

        public void AjouterCategorie(EnumCategorie categorie)
        {
            Preferences.Categories.Add(categorie);
        }

        public void AjouterDirecteur(Directeur directeur)
        {
            Preferences.Directeurs.Add(directeur);
        }

        public void AjouterRealisateur(Realisateur realisateur)
        {
            Preferences.Realisateurs.Add(realisateur);
        }

        public override string ToString()
        {
            return Prenom + " " + Nom + " - " + Username;
        }
    }
}
