using System.Collections.ObjectModel;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Domain;
using MongoDB.Driver;

namespace CineQuebec.Windows.DAL.Repositories;

public class RepositoryFilmNotes : GenericRepository<FilmNote>, IRepositoryFilmNotes
{
    public ReadOnlyCollection<FilmNote> LoadFilmNotes()
    {
        try
        {
            ReadOnlyCollection<FilmNote> filmNotes = new ReadOnlyCollection<FilmNote>(Collection.Aggregate().ToList());
            return filmNotes;
        }
        catch (Exception e)
        {
            throw new Exception("Impossible de charger les notes des films", e);
        }
        
    }

    public FilmNote AddFilmNote(FilmNote pFilmNote)
    {
        try
        {
            Collection.InsertOne(pFilmNote);
            return pFilmNote;
        }
        catch (Exception e)
        {
            throw new Exception("Impossible d'ajouter la note du film", e);
        }
        
    }
}