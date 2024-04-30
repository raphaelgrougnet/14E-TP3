using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Domain
{
    public interface IPreference
    {
        List<Acteur> Acteurs { get; set; }
        List<Realisateur> Realisateurs { get; set; }
        List<Directeur> Directeurs { get; set; }
        List<EnumCategorie> Categories { get; set; }
    }
}
