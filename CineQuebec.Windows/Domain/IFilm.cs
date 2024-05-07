namespace CineQuebec.Windows.Domain
{
    public interface IFilm
    {
        public string Titre { get; init; }
        public float Duree { get; init; }
        public DateTime DateSortie { get; init; }
        public bool EstArchive { get; set; }
        public bool EstALaffiche { get; set; }
        public EnumCategorie Categorie { get; init; }
        public List<Acteur> Acteurs { get; init; }
        public List<Realisateur> Realisateurs { get; init; }
        public List<Directeur> Directeurs { get; init; }
        public List<Abonne> AbonneVisonnes { get; init; }
    }
}