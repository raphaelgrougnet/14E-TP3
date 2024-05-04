using MongoDB.Bson;

namespace CineQuebec.Windows.Domain;

public class Salle : Entite, ISalle
{
    public Salle(ObjectId pId, string pNom, int pCapacite) : base(pId)
    {
        Nom = pNom;
        Capacite = pCapacite;
    }

    public string Nom { get; set; }
    public int Capacite { get; set; }
    
    public override string ToString()
    {
        return $"Salle {Nom} ({Capacite} places)";
    }
}