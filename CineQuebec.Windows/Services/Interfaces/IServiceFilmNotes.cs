using System.Collections.ObjectModel;
using CineQuebec.Windows.Domain;

namespace CineQuebec.Windows.Services.Interfaces;

public interface IServiceFilmNotes
{
    public ReadOnlyCollection<FilmNote> LoadFilmNotes();
    public FilmNote AddFilmNote(Film pFilm, byte pNote, Abonne pAbonne);
    public FilmNote? ObtenirFilmNoteParAbonneEtFilm(Abonne pAbonne, Film pFilm);
}