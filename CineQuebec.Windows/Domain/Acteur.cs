using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CineQuebec.Windows.Domain
{
    public class Acteur : Entite, IActeur
    {
        public string Nom { get; init; }

        public Acteur(ObjectId id ,string nom) : base(id)
        {
            Nom = nom;
        }

        public Acteur(string nom) : base(ObjectId.GenerateNewId())
        {
            Nom = nom;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Acteur)obj;
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
