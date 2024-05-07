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

        public Recompense(ObjectId id,string titre, EnumType type, string description, ObjectId idAbonne) : base(id)
        {
            Titre = titre;
            Type = type;
            Description = description;
            this.idAbonne = idAbonne;
        }

        public Recompense(string titre, EnumType type, string description, ObjectId idAbonne) : base(ObjectId.GenerateNewId())
        {
            Titre = titre;
            Type = type;
            Description = description;
            this.idAbonne = idAbonne;
        }

        public override string ToString()
        {
            return $"{Titre}";
        }

    }
}
