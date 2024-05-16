using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Domain
{
    public class Directeur : Entite, IDirecteur
    {
        public string Nom { get; init; }

        public Directeur(ObjectId id, string nom) : base(id)
        {
            Nom = nom;
        }

        public Directeur(string nom) : base(ObjectId.GenerateNewId())
        {
            Nom = nom;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Directeur)obj;
            return Nom == other.Nom;
        }

        public override int GetHashCode()
        {
            return Nom != null ? Nom.GetHashCode() : 0;
        }


        public override string ToString()
        {
            return $"{Nom}";
        }
    }
}
