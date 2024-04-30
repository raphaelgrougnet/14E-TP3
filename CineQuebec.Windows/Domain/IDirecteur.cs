using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Domain
{
    public interface IDirecteur
    {
        public string Nom { get; init; }
        public string Prenom { get; init; }

    }
}
