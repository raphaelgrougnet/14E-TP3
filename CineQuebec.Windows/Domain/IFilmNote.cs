namespace CineQuebec.Windows.Domain;

public interface IFilmNote
{
    public Film Film { get; set; }
    public byte Note { get; set; }
    public Abonne Abonne { get; set; }
}