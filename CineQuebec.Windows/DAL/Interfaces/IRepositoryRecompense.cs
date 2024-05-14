using CineQuebec.Windows.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Interfaces
{
    public interface IRepositoryRecompense
    {
        public bool AddRecompenseToAbonne(Recompense recompense);
    }
}
