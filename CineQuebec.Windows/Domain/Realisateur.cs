using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Domain
{
    public class Realisateur : Entite, IRealisateur
    {
        public string Nom { get; init; }

        public Realisateur(ObjectId id, string nom): base(id)
        {
            Nom = nom;
        }

        public Realisateur(string nom) : base(ObjectId.GenerateNewId())
        {
            Nom = nom;
        }

        public override string ToString()
        {
            return $"{Nom}";
        }
    }
}
