namespace CineQuebec.Windows.Domain;

public interface IProjection
{
    string Salle { get; set; }
    DateTime Date { get; set; }
    Film Film { get; set; }
    string ToString();
}