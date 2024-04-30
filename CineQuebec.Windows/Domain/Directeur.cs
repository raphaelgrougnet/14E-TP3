using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Domain
{
    public class Directeur : IDirecteur
    {
        public string Nom { get; init; }
        public string Prenom { get; init; }

        public Directeur(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }

        public override string ToString()
        {
            return $"{Prenom} {Nom}";
        }
    }
}
