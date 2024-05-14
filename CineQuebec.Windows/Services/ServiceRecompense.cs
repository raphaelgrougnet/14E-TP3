using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Services
{
    public class ServiceRecompense : IRepositoryRecompense
    {
        private IRepositoryRecompense _repositoryRecompense;
        public ServiceRecompense(IRepositoryRecompense repositoryRecompense)
        {
            _repositoryRecompense = repositoryRecompense;
        }
        public bool AddRecompenseToAbonne(Recompense recompense)
        {
            return _repositoryRecompense.AddRecompenseToAbonne(recompense);
        }
    }
}
