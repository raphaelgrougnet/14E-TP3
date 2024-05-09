using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Collections.ObjectModel;

namespace CineQuebec.Windows.Domain
{
    public class Film : Entite, IFilm
    {
        public string Titre { get; init; }
        public float Duree { get; init; }
        public DateTime DateSortie { get; init; }
        public bool EstArchive { get; set; } = false;
        public bool EstALaffiche { get; set; } = false;
        public EnumCategorie Categorie { get; init; }
        public List<Acteur> Acteurs { get; init; }
        public List<Realisateur> Realisateurs { get; init; }
        public List<Directeur> Directeurs { get; init; }

        public Film(ObjectId id, string titre, float duree, DateTime dateSortie,
            EnumCategorie categorie, List<Acteur> acteurs, List<Realisateur> realisateurs, List<Directeur> directeurs) : base(id)
        {
            Titre = titre;
            Duree = duree;
            DateSortie = dateSortie;
            Categorie = categorie;
            Acteurs = acteurs;
            Realisateurs = realisateurs;
            Directeurs = directeurs;
        }
        
        public Film() : base(ObjectId.GenerateNewId())
        {
            
        }

        public override string ToString()
        {
            return Titre;
        }
    }
}
