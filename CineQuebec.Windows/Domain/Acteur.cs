using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Domain
{
    public class Acteur : IActeur
    {
        public string Nom { get; init; }
        public string Prenom { get; init; }

        public Acteur(string nom, string prenom)
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
