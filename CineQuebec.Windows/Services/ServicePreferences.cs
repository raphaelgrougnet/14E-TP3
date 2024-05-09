using CineQuebec.Windows.Services.Interfaces;
using CineQuebec.Windows.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Services
{
    public class ServicePreferences : IServicePreferences
    {
        public const int MAX_PREFERENCES = 5;

        public bool IsAlreadyInList<T>(List<T> list, T item) where T : Entite
        {
            foreach (T listItem in list)
            {
                if (listItem._id == item._id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CategorieIsInList(List<EnumCategorie> list, EnumCategorie categorie)
        {
            foreach (EnumCategorie listCategorie in list)
            {
                if (listCategorie == categorie)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsMaxPreferencesReached(int lenght)
        {
            if(lenght <= MAX_PREFERENCES)
                return true;
            else
                return false;
        }
    }
}
