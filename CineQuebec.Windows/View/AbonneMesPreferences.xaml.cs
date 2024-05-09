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
    /// Interaction logic for AbonneMesPreferences.xaml
    /// </summary>
    public partial class AbonneMesPreferences : UserControl
    {
        private Abonne _abonne;
        public AbonneMesPreferences(Abonne abonne)
        {
            InitializeComponent();
            _abonne = abonne;
            AfficherLesListes();
        }

        private void AfficherLesListes()
        {
            lstActeurs.Items.Clear();
            lstRealisateurs.Items.Clear();
            lstDirecteurs.Items.Clear();
            lstCategories.Items.Clear();
            
            lstActeurs.ItemsSource = _abonne.Preferences.Acteurs;
            lstRealisateurs.ItemsSource = _abonne.Preferences.Realisateurs;
            lstDirecteurs.ItemsSource = _abonne.Preferences.Directeurs;
            lstCategories.ItemsSource = _abonne.Preferences.Categories;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).AbonneAjouterPreference(_abonne);
        }
        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).AbonneHomeControl(_abonne);
        }
    }
}
