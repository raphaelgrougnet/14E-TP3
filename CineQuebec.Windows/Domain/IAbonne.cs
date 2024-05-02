namespace CineQuebec.Windows.Domain
{
    public interface IAbonne
    {
        string Courriel { get; set; }
        DateTime DateAdhesion { get; init; }
        bool EstAdmin { get; init; }
        byte[] MotDePasse { get; set; }
        string Nom { get; set; }
        string Prenom { get; set; }
        byte[] Salt { get; set; }
        string Username { get; set; }
        Preference Preferences { get; set; }
        

        string ToString();
    }
}