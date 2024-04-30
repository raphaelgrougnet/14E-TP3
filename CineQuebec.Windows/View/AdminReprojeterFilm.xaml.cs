using System.Windows;
using CineQuebec.Windows.Domain;

namespace CineQuebec.Windows.View;

public partial class AdminReprojeterFilm : Window
{
    Film _film;
    public AdminReprojeterFilm(Film pFilm)
    {
        InitializeComponent();
        _film = pFilm;
    }
}