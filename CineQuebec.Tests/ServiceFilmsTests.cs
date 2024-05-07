using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services;
using MongoDB.Bson;
using Moq;

namespace CineQuebec.Tests;

public class ServiceFilmsTests
{
    [Fact]
    public void UpdateFilmShouldUpdateInRepo()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryFilms>();
        var service = new ServiceFilms(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Film1", 120f, DateTime.Now, EnumCategorie.Action, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<Abonne>());
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
        var film = new Film(ObjectId.GenerateNewId(), "Film1", 120f, DateTime.Now, EnumCategorie.Action, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<Abonne>() );
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
        var film = new Film(ObjectId.GenerateNewId(), "Film1", 120f, DateTime.Now, EnumCategorie.Action, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<Abonne>() );
        mockRepo.Setup(r => r.UpdateFilm(film)).Throws(new Exception("Erreur de mise à jour du film"));
    
        // Act & Assert
        var ex = Assert.Throws<Exception>(() => service.UpdateFilm(film));
        Assert.Equal("Erreur de mise à jour du film", ex.Message);
    }
}