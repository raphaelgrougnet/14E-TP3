using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Repositories
{
    public class RepositoryDirecteur : GenericRepository<Directeur>, IRepositoryDirecteur
    {
        public ReadOnlyCollection<Directeur> LoadDirecteurs()
        {
            try
            {
                ReadOnlyCollection<Directeur> directeurs = new ReadOnlyCollection<Directeur>(Collection.Aggregate().ToList());
                return directeurs;
            }
            catch (Exception e)
            {
                throw new Exception("Erreur lors de la récupération des acteurs", e);
            }
        }
    }
}
