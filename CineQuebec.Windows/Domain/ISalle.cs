namespace CineQuebec.Windows.Domain;

public interface ISalle
{
    public string Nom { get; set; }
    public int Capacite { get; set; }
    public string ToString();
}