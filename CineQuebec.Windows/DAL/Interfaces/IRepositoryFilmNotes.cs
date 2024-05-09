using System.Collections.ObjectModel;
using CineQuebec.Windows.Domain;

namespace CineQuebec.Windows.DAL.Interfaces;

public interface IRepositoryFilmNotes
{
    public ReadOnlyCollection<FilmNote> LoadFilmNotes();
    public FilmNote AddFilmNote(FilmNote pFilmNote);
    public FilmNote? ObtenirFilmNoteParAbonneEtFilm(Abonne pAbonne, Film pFilm);
    FilmNote UpdateFilmNote(FilmNote filmNote);
}