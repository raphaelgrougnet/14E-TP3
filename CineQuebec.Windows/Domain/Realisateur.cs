using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Domain
{
    public class Realisateur : IRealisateur
    {
        public string Nom { get; init; }

        public Realisateur(string nom)
        {
            Nom = nom;
        }

        public override string ToString()
        {
            return $"{Nom}";
        }
    }
}
