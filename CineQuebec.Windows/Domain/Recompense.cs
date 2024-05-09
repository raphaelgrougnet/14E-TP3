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
        public uint NombreRestant { get; set; } = 30;
        public ObjectId idAbonne { get; init; }

        public Recompense(ObjectId id,string titre, EnumType type, string description, uint nombreRestant, ObjectId idAbonne) : base(id)
        {
            Titre = titre;
            Type = type;
            Description = description;
            NombreRestant = nombreRestant;
            this.idAbonne = idAbonne;
        }

        public Recompense(string titre, EnumType type, string description, uint nombreRestant, ObjectId idAbonne) : base(ObjectId.GenerateNewId())
        {
            Titre = titre;
            Type = type;
            Description = description;
            NombreRestant = nombreRestant;
            this.idAbonne = idAbonne;
        }

        public bool DecrementerNombreRestant()
        {
            if (NombreRestant > 0)
            {
                NombreRestant--;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Titre}";
        }

    }
}
