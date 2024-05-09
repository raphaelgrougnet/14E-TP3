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

    public FilmNote? ObtenirFilmNoteParAbonneEtFilm(Abonne pAbonne, Film pFilm)
    {
        try
        {
            return Collection.Find(x => x.Abonne._id == pAbonne._id && x.Film._id == pFilm._id).FirstOrDefault();
        }
        catch (Exception e)
        {
            throw new Exception("Impossible d'obtenir la note du film", e);
        }
    }

    public FilmNote UpdateFilmNote(FilmNote filmNote)
    {
        try
        {
            Collection.ReplaceOne(x => x._id == filmNote._id, filmNote);
            return filmNote;
        }
        catch (Exception e)
        {
            throw new Exception("Impossible de mettre à jour la note du film", e);
        }
    }
}