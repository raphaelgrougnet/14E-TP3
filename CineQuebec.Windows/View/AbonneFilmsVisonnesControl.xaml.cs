using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services;

namespace CineQuebec.Windows.View;

public partial class AbonneFilmsVisonnesControl : UserControl
{
    private RepositoryFilmNotes _repositoryFilmNotes;
    private ServiceFilmNotes _serviceFilmNotes;
    private Abonne _abonne;
    private ReadOnlyCollection<Film> _filmsVisionnes;
    
    public AbonneFilmsVisonnesControl(Abonne pAbonne)
    {
        InitializeComponent();
        _repositoryFilmNotes = new RepositoryFilmNotes();
        _serviceFilmNotes = new ServiceFilmNotes(_repositoryFilmNotes);
        _abonne = pAbonne;
        ChargerListeFilmsVisionnes();
    }
    
    private void ChargerListeFilmsVisionnes()
    {
        _filmsVisionnes = new ReadOnlyCollection<Film>(_abonne.FilmsVisionnes);
        lstFilms.ItemsSource = _filmsVisionnes;
    }


    private void BtnRetour_OnClick(object sender, RoutedEventArgs e)
    {
        ((MainWindow)Application.Current.MainWindow).AbonneHomeControl(_abonne);
    }

    private void LstFilms_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (lstFilms.SelectedItem != null)
            allStars.IsEnabled = true;
        else
        {
            allStars.IsEnabled = false;
            return;
        }
            
        
        Film film = (Film)lstFilms.SelectedItem;
        FilmNote? filmNote = _serviceFilmNotes.ObtenirFilmNoteParAbonneEtFilm(_abonne, film);
        if (filmNote != null)
        {
            switch (filmNote.Note)
            {
                case 1:
                    Star1Selected();
                    break;
                case 2:
                    Star2Selected();
                    break;
                case 3:
                    Star3Selected();
                    break;
                case 4:
                    Star4Selected();
                    break;
                case 5:
                    Star5Selected();
                    break;
            }
        }
        else
        {
            DeselectAllStars();
        }
        
    }
    
    private void Star1_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        Star1Selected();
        SaveNote(1);
    }

    private void Star2_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        Star2Selected();
        SaveNote(2);
    }

    private void Star3_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        Star3Selected();
        SaveNote(3);
    }

    private void Star4_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        Star4Selected();
        SaveNote(4);
    }

    private void Star5_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        Star5Selected();
        SaveNote(5);
    }
    
    private void SaveNote(byte note)
    {
        Film film = (Film)lstFilms.SelectedItem;
        _serviceFilmNotes.AddFilmNote(film, note, _abonne);
    }

    private void DeselectAllStars()
    {
        star1.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoileVide.png"));
        star2.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoileVide.png"));
        star3.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoileVide.png"));
        star4.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoileVide.png"));
        star5.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoileVide.png"));
    }
    
    private void Star1Selected()
    {
        DeselectAllStars();
        star1.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoilePleine.png"));
    }
    
    private void Star2Selected()
    {
        DeselectAllStars();
        star1.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoilePleine.png"));
        star2.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoilePleine.png"));
    }
    
    private void Star3Selected()
    {
        DeselectAllStars();
        star1.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoilePleine.png"));
        star2.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoilePleine.png"));
        star3.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoilePleine.png"));
    }
    
    private void Star4Selected()
    {
        DeselectAllStars();
        star1.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoilePleine.png"));
        star2.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoilePleine.png"));
        star3.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoilePleine.png"));
        star4.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoilePleine.png"));
    }
    
    private void Star5Selected()
    {
        DeselectAllStars();
        star1.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoilePleine.png"));
        star2.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoilePleine.png"));
        star3.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoilePleine.png"));
        star4.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoilePleine.png"));
        star5.Source = new BitmapImage(new Uri("pack://application:,,,/CineQuebec.Windows;component/assets/etoilePleine.png"));
    }


   
}