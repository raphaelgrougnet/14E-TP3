namespace CineQuebec.Windows.Domain;

public interface IProjection
{
    Salle Salle { get; set; }
    DateTime Date { get; set; }
    Film Film { get; set; }
    string ToString();
}