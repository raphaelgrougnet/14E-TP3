using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Repositories
{
    public class RepositoryRecompense : GenericRepository<Recompense>, IRepositoryRecompense
    {
        public bool AddRecompenseToAbonne(Recompense recompense)
        {
            try
            {
                Collection.InsertOne(recompense);
                return true;
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'ajouter le film " + ex.Message, "Erreur");
            }

            return false;
        }
    }
}
