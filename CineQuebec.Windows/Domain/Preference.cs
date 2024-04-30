using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Domain
{
    public class Preference : IPreference
    {
        public List<Acteur> Acteurs { get; set; }
        public List<Realisateur> Realisateurs { get; set; }
        public List<Directeur> Directeurs { get; set; }
        public List<EnumCategorie> Categories { get; set; }

        public Preference(List<Acteur> acteurs, List<Realisateur> realisateurs, List<Directeur> directeurs, List<EnumCategorie> categories)
        {
            Acteurs = acteurs;
            Realisateurs = realisateurs;
            Directeurs = directeurs;
            Categories = categories;
        }

        public Preference()
        {
            Acteurs = new List<Acteur>();
            Realisateurs = new List<Realisateur>();
            Directeurs = new List<Directeur>();
            Categories = new List<EnumCategorie>();
        }
    }
}
