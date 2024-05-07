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
        FilmNote filmNote = new FilmNote(ObjectId.GenerateNewId(), pFilm, pNote, pAbonne);
        return _repositoryFilmNotes.AddFilmNote(filmNote);
    }
}