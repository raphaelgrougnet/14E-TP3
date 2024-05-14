using CineQuebec.Windows.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Services.Interfaces
{
    public interface IServiceRecompense
    {
        public bool AddRecompenseToAbonne(Recompense recompense);
    }
}
