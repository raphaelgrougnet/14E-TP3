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
    public class RepositoryRealisateur : GenericRepository<Realisateur>, IRepositoryRealisateur
    {
        public ReadOnlyCollection<Realisateur> LoadRealisateurs()
        {
            try
            {
                ReadOnlyCollection<Realisateur> realisateurs = new ReadOnlyCollection<Realisateur>(Collection.Aggregate().ToList());
                return realisateurs;
            }
            catch (Exception e)
            {
                throw new Exception("Erreur lors de la récupération des acteurs", e);
            }
        }
    }
}
