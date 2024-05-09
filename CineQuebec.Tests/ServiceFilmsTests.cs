using System.Collections.ObjectModel;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services;
using MongoDB.Bson;
using Moq;

namespace CineQuebec.Tests;

public class ServiceFilmsTests
{
    [Fact]
    public void GetFilmsShouldReturnAllFilms()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryFilms>();
        var service = new ServiceFilms(mockRepo.Object);
        var films = new ReadOnlyCollection<Film>(new List<Film>
        {
            new Film(ObjectId.GenerateNewId(), "Film1", 120f, DateTime.Now, EnumCategorie.Action, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>()),
            new Film(ObjectId.GenerateNewId(), "Film2", 90f, DateTime.Now, EnumCategorie.Action, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>())
        });
        mockRepo.Setup(r => r.LoadFilms()).Returns(films);

        // Act
        var result = service.GetFilms();

        // Assert
        Assert.Equal(films, result);
    }

    [Fact]
    public void AddFilmShouldReturnAddedFilm()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryFilms>();
        var service = new ServiceFilms(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Film1", 120f, DateTime.Now, EnumCategorie.Action, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>());
        mockRepo.Setup(r => r.AddFilm(film)).Returns(film);

        // Act
        var result = service.AddFilm(film);

        // Assert
        Assert.Equal(film, result);
    }

    [Fact]
    public void LoadFilmsAfficheShouldReturnFilmsInShow()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryFilms>();
        var service = new ServiceFilms(mockRepo.Object);
        var films = new ReadOnlyCollection<Film>(new List<Film>
        {
            new Film(ObjectId.GenerateNewId(), "Film1", 120f, DateTime.Now, EnumCategorie.Action, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>()),
            new Film(ObjectId.GenerateNewId(), "Film2", 90f, DateTime.Now, EnumCategorie.Action, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>())
        });
        foreach (Film film in films)
        {
            film.EstALaffiche = true;
        }
        mockRepo.Setup(r => r.LoadFilmsAffiche()).Returns(films);

        // Act
        var result = service.LoadFilmsAffiche();

        // Assert
        Assert.Equal(films, result);
    }

    [Fact]
    public void UpdateFilmShouldUpdateInRepo()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryFilms>();
        var service = new ServiceFilms(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Film1", 120f, DateTime.Now, EnumCategorie.Action, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>());
        mockRepo.Setup(r => r.UpdateFilm(film)).Returns(film);
        
        // Act
        film.EstALaffiche = true;
        var result = service.UpdateFilm(film);
        
        // Assert
        mockRepo.Verify(r => r.UpdateFilm(film), Times.Once);
    }
    
    [Fact]
    public void UpdateFilmShouldReturnUpdatedFilm()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryFilms>();
        var service = new ServiceFilms(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Film1", 120f, DateTime.Now, EnumCategorie.Action, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>() );
        mockRepo.Setup(r => r.UpdateFilm(film)).Returns(film);
    
        // Act
        film.EstALaffiche = true;
        var result = service.UpdateFilm(film);
    
        // Assert
        Assert.Equal(film, result);
    }

    [Fact]
    public void UpdateFilmShouldThrowExceptionWhenRepoFails()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryFilms>();
        var service = new ServiceFilms(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Film1", 120f, DateTime.Now, EnumCategorie.Action, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>() );
        mockRepo.Setup(r => r.UpdateFilm(film)).Throws(new Exception("Erreur de mise à jour du film"));
    
        // Act & Assert
        var ex = Assert.Throws<Exception>(() => service.UpdateFilm(film));
        Assert.Equal("Erreur de mise à jour du film", ex.Message);
    }
}