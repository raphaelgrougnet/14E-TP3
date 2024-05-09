using MongoDB.Bson;

namespace CineQuebec.Windows.Domain;

public class FilmNote : Entite, IFilmNote
{
    public FilmNote(ObjectId id, Film film, byte note, Abonne abonne) : base(id)
    {
        Film = film;
        Note = note;
        Abonne = abonne;
    }
    
    public FilmNote() : base(ObjectId.GenerateNewId())
    {
    }

    public Film Film { get; set; }
    public byte Note { get; set; }
    public Abonne Abonne { get; set; }
}