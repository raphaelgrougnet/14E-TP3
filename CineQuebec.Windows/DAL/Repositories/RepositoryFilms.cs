using CineQuebec.Windows.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CineQuebec.Windows.DAL.Repositories
{
    public class RepositoryFilms : GenericRepository<Film>
    {
        public List<Film> LoadFilms()
        {
            List<Film> films = new List<Film>();

            try
            {
                films = Collection.Aggregate().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collection de films" + ex.Message, "Erreur");
            }
            return films;
        }

        public Film AddFilm(Film film)
        {
            try
            {
                Collection.InsertOne(film);
                return film;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'ajouter le film " + ex.Message, "Erreur");
            }

            return null;
        }

        public List<Film> LoadFilmsAffiche()
        {
            var films = new List<Film>();

            try
            {
                films = Collection.Find(filmsALaffiche => filmsALaffiche.EstALaffiche == true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir la collections des films à l'affiche" + ex.Message, "Erreur");
            }
            return films;
        }
    }
}
