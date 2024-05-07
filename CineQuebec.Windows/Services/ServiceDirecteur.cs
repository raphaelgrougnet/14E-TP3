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
    public class ServiceDirecteur : IServiceDirecteur
    {
        private IRepositoryDirecteur _repositoryDirecteur;

        public ReadOnlyCollection<Directeur> LoadDirecteurs()
        {
            return _repositoryDirecteur.LoadDirecteurs();
        }
    }
}
