using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Domain
{
    public class Preference : Entite, IPreference
    {
        public List<Acteur> Acteurs { get; set; }
        public List<Realisateur> Realisateurs { get; set; }
        public List<Directeur> Directeurs { get; set; }
        public List<EnumCategorie> Categories { get; set; }

        public Preference(ObjectId id, List<Acteur> acteurs, List<Realisateur> realisateurs, List<Directeur> directeurs, List<EnumCategorie> categories): base(id)
        {
            Acteurs = acteurs;
            Realisateurs = realisateurs;
            Directeurs = directeurs;
            Categories = categories;
        }

        public Preference(ObjectId id) : base(id)
        {
            Acteurs = new List<Acteur>();
            Realisateurs = new List<Realisateur>();
            Directeurs = new List<Directeur>();
            Categories = new List<EnumCategorie>();
        }
    }
}
