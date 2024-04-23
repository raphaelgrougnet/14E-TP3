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
        public string Acteurs { get; init; }
        public string Realisateurs { get; init; }
        public string Directeurs { get; init; }

        public Film(ObjectId id, string titre, float duree, DateTime dateSortie,
            EnumCategorie categorie, string acteurs, string realisateurs, string directeurs) : base(id)
        {
            Titre = titre;
            Duree = duree;
            DateSortie = dateSortie;
            Categorie = categorie;
            Acteurs = acteurs;
            Realisateurs = realisateurs;
            Directeurs = directeurs;
        }

        public override string ToString()
        {
            return Titre;
        }
    }
}
