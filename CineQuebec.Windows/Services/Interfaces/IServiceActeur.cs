using CineQuebec.Windows.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Services.Interfaces
{
    public interface IServiceActeur
    {
        public ReadOnlyCollection<Acteur> LoadActeurs();

    }
}
