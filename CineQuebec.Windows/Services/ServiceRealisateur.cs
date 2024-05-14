using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Services
{
    public class ServiceRealisateur : IServiceRealisateur
    {
        private IRepositoryRealisateur _repositoryRealisateur;

        public ServiceRealisateur(IRepositoryRealisateur repositoryRealisateur)
        {
            _repositoryRealisateur = repositoryRealisateur;
        }

        public ReadOnlyCollection<Realisateur> LoadRealisateurs()
        {
            return _repositoryRealisateur.LoadRealisateurs();
        }
    }
}
