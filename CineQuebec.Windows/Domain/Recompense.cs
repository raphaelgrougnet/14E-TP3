using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Domain
{
    public class Recompense : Entite, IRecompense
    {
        public string Titre { get; init; }
        public EnumType Type { get; init; }
        public string Description { get; init; }
        public ObjectId idAbonne { get; init; }
        public ObjectId idFilm { get; init; }

        public Recompense(ObjectId id, string titre, EnumType type, string description, ObjectId idAbonne, ObjectId idFilm) : base(id)
        {
            Titre = titre;
            Type = type;
            Description = description;
            this.idAbonne = idAbonne;
            this.idFilm = idFilm;
        }

        public Recompense(string titre, EnumType type, string description, ObjectId idAbonne, ObjectId idFilm) : base(ObjectId.GenerateNewId())
        {
            Titre = titre;
            Type = type;
            Description = description;
            this.idAbonne = idAbonne;
            this.idFilm = idFilm;
        }


        public override string ToString()
        {
            return $"{Titre}";
        }

    }
}
