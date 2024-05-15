using CineQuebec.Windows.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Services.Interfaces
{
    public interface IServicePreferences
    {

        public bool IsAlreadyInList<T>(List<T> list, T item) where T : Entite;

        public bool CategorieIsInList(List<EnumCategorie> list, EnumCategorie categorie);

        public bool IsMaxPreferencesReached(int lenght, int max);

        public bool IsMaxCategoriePreferencesReached(int lenght, int max);
    }
}
