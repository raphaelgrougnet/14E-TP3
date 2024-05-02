using CineQuebec.Windows.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CineQuebec.Windows.View
{
    /// <summary>
    /// Interaction logic for AbonneAjouterPreference.xaml
    /// </summary>
    public partial class AbonneAjouterPreference : UserControl
    {
        private Abonne _abonne;
        public AbonneAjouterPreference(Abonne abonne)
        {
            InitializeComponent();
            _abonne = abonne;
        }
    }
}
