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
        public string Acteurs { get; init; }
        public string Realisateurs { get; init; }
        public string Directeurs { get; init; }
    }
}