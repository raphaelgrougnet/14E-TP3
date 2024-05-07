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
    public class RepositoryActeur : GenericRepository<Acteur>, IRepositoryActeur
    {
        public ReadOnlyCollection<Acteur> LoadActeurs()
        {
            try
            {
                ReadOnlyCollection<Acteur> acteurs = new ReadOnlyCollection<Acteur>(Collection.Aggregate().ToList());
                return acteurs;
            }
            catch (Exception e)
            {
                throw new Exception("Erreur lors de la récupération des acteurs", e);
            }
        }
    }
}
