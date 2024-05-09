using System.Collections.ObjectModel;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services.Interfaces;
using MongoDB.Bson;

namespace CineQuebec.Windows.Services;

public class ServiceFilmNotes : IServiceFilmNotes
{
    private readonly IRepositoryFilmNotes _repositoryFilmNotes;
    
    public ServiceFilmNotes(IRepositoryFilmNotes pRepositoryFilmNotes)
    {
        _repositoryFilmNotes = pRepositoryFilmNotes;
    }
    
    public ReadOnlyCollection<FilmNote> LoadFilmNotes()
    {
        return _repositoryFilmNotes.LoadFilmNotes();
    }

    public FilmNote AddFilmNote(Film pFilm, byte pNote, Abonne pAbonne)
    {
        ReadOnlyCollection<FilmNote> filmNotes = LoadFilmNotes();
        foreach (FilmNote filmNoteBoucle in filmNotes)
        {
            if (filmNoteBoucle.Film._id == pFilm._id && filmNoteBoucle.Abonne._id == pAbonne._id)
            {
                filmNoteBoucle.Note = pNote;
                return _repositoryFilmNotes.UpdateFilmNote(filmNoteBoucle);
            }
            
        }
        FilmNote filmNote = new FilmNote(ObjectId.GenerateNewId(), pFilm, pNote, pAbonne);
        return _repositoryFilmNotes.AddFilmNote(filmNote);
    }

    public FilmNote? ObtenirFilmNoteParAbonneEtFilm(Abonne pAbonne, Film pFilm)
    {
        return _repositoryFilmNotes.ObtenirFilmNoteParAbonneEtFilm(pAbonne, pFilm);
    }
    
}