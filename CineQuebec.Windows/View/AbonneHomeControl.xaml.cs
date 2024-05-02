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
    /// Interaction logic for AbonneHomeControl.xaml
    /// </summary>
    public partial class AbonneHomeControl : UserControl
    {
        private Abonne _abonne;
        public AbonneHomeControl(Abonne abonne)
        {
            InitializeComponent();
            _abonne = abonne;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).AbonneMesPreferences(_abonne);
        }
    }
}
