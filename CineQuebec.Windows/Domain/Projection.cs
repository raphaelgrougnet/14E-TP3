using MongoDB.Bson;

namespace CineQuebec.Windows.Domain;

public class Projection : Entite, IProjection
{
    public Salle Salle { get; set; }
    public DateTime Date { get; set; }
    public Film Film { get; set; }
    
    public Projection(ObjectId pId, Salle pSalle, DateTime pDate, Film pFilm) : base(pId)
    {
        Salle = pSalle;
        Date = pDate;
        Film = pFilm;
    }
    
    public override string ToString()
    {
        return $"Salle: {Salle}, Date: {Date}, Film: {Film}";
    }
}