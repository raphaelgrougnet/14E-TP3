using System.Collections.ObjectModel;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services;
using MongoDB.Bson;
using Moq;

namespace CineQuebec.Tests;

public class ServiceProjectionsTests
{
    [Fact]
    public void ProgrammerReprojectionShouldReturnReprojection()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryProjections>();
        var service = new ServiceProjections(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Titre", 120, DateTime.Now, EnumCategorie.Comedie, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<Abonne>());
        var salle = new Salle(ObjectId.GenerateNewId(), "Salle", 25); 
        var projection = new Projection(ObjectId.GenerateNewId(), salle, DateTime.Now, new Film(ObjectId.GenerateNewId(), "Titre", 120, DateTime.Now, EnumCategorie.Comedie, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<Abonne>()));
        mockRepo.Setup(r => r.AddProjection(It.IsAny<Projection>())).Returns(projection);
        
        // Act
        var result = service.ProgrammerReprojection(film, salle);
        
        // Assert
        Assert.Equal(projection, result);
        mockRepo.Verify(r => r.AddProjection(It.IsAny<Projection>()), Times.Once);
    }
    
    [Fact]
    public void ProgrammerReprojectionShouldReturnNullWhenRepoReturnsNull()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryProjections>();
        var service = new ServiceProjections(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Titre", 120, DateTime.Now, EnumCategorie.Comedie, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<Abonne>());
        var salle = new Salle(ObjectId.GenerateNewId(), "Salle", 25);
        mockRepo.Setup(r => r.AddProjection(It.IsAny<Projection>())).Returns((Projection)null);

        // Act
        var result = service.ProgrammerReprojection(film, salle);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ProgrammerReprojectionShouldThrowExceptionWhenRepoThrowsException()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryProjections>();
        var service = new ServiceProjections(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Titre", 120, DateTime.Now, EnumCategorie.Comedie, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<Abonne>());
        var salle = new Salle(ObjectId.GenerateNewId(), "Salle", 25);
        mockRepo.Setup(r => r.AddProjection(It.IsAny<Projection>())).Throws(new Exception("Erreur lors de l'ajout de la projection"));

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => service.ProgrammerReprojection(film, salle));
        Assert.Equal("Erreur lors de l'ajout de la projection", ex.Message);
    }

    [Fact]
    public void ProgrammerReprojectionShouldThrowExceptionWhenFilmIsNull()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryProjections>();
        var service = new ServiceProjections(mockRepo.Object);
        var salle = new Salle(ObjectId.GenerateNewId(), "Salle", 25);

        // Act & Assert
        var ex = Assert.Throws<ArgumentNullException>(() => service.ProgrammerReprojection(null, salle));
        Assert.Equal("Le film ne peut pas être null", ex.ParamName);
    }

    [Fact]
    public void ProgrammerReprojectionShouldThrowExceptionWhenSalleIsNull()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryProjections>();
        var service = new ServiceProjections(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Titre", 120, DateTime.Now, EnumCategorie.Comedie, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<Abonne>());

        // Act & Assert
        var ex = Assert.Throws<ArgumentNullException>(() => service.ProgrammerReprojection(film, null));
        Assert.Equal("La salle ne peut pas être null", ex.ParamName);
    }
    
    [Fact]
    public void LoadProjectionsShouldReturnProjections()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryProjections>();
        var service = new ServiceProjections(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Titre", 120, DateTime.Now, EnumCategorie.Comedie, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<Abonne>());
        var salle = new Salle(ObjectId.GenerateNewId(), "Salle", 25);
        var projection = new Projection(ObjectId.GenerateNewId(), salle, DateTime.Now, film);
        var projections = new ReadOnlyCollection<Projection>(new List<Projection>{projection});
        mockRepo.Setup(r => r.LoadProjections()).Returns(projections);
        
        // Act
        var result = service.GetProjections();
        
        // Assert
        Assert.Single(result);
        Assert.Equal(projections, result);
    }
    
    [Fact]
    public void LoadProjectionsShouldReturnEmptyWhenRepoReturnsEmpty()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryProjections>();
        var service = new ServiceProjections(mockRepo.Object);
        mockRepo.Setup(r => r.LoadProjections()).Returns(new ReadOnlyCollection<Projection>(new List<Projection>()));

        // Act
        var result = service.GetProjections();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void LoadProjectionsShouldReturnNullWhenRepoReturnsNull()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryProjections>();
        var service = new ServiceProjections(mockRepo.Object);
        mockRepo.Setup(r => r.LoadProjections()).Returns((ReadOnlyCollection<Projection>)null);

        // Act
        var result = service.GetProjections();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LoadProjectionsShouldThrowExceptionWhenRepoThrowsException()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryProjections>();
        var service = new ServiceProjections(mockRepo.Object);
        mockRepo.Setup(r => r.LoadProjections()).Throws(new Exception("Erreur lors du chargement des projections"));

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => service.GetProjections());
        Assert.Equal("Erreur lors du chargement des projections", ex.Message);
    }
    
    [Fact]
    public void IsFilmEnSalleShouldReturnTrueWhenFilmIsInSalle()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryProjections>();
        var service = new ServiceProjections(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Titre", 120, DateTime.Now, EnumCategorie.Comedie, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<Abonne>());
        var salle = new Salle(ObjectId.GenerateNewId(), "Salle", 25);
        var projection = new Projection(ObjectId.GenerateNewId(), salle, DateTime.Now, film);
        var projections = new ReadOnlyCollection<Projection>(new List<Projection>{projection});
        mockRepo.Setup(r => r.LoadProjections()).Returns(projections);
        
        // Act
        var result = service.IsFilmEnSalle(film);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void IsFilmEnSalleShouldReturnFalseWhenFilmIsNotInSalle()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryProjections>();
        var service = new ServiceProjections(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Titre", 120, DateTime.Now, EnumCategorie.Comedie, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<Abonne>());
        var salle = new Salle(ObjectId.GenerateNewId(), "Salle", 25);
        var otherFilm = new Film(ObjectId.GenerateNewId(), "Autre Titre", 120, DateTime.Now, EnumCategorie.Comedie, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<Abonne>());
        var projection = new Projection(ObjectId.GenerateNewId(), salle, DateTime.Now, otherFilm);
        var projections = new ReadOnlyCollection<Projection>(new List<Projection>{projection});
        mockRepo.Setup(r => r.LoadProjections()).Returns(projections);
        
        // Act
        var result = service.IsFilmEnSalle(film);
        
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsFilmEnSalleShouldReturnFalseWhenRepoReturnsEmpty()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryProjections>();
        var service = new ServiceProjections(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Titre", 120, DateTime.Now, EnumCategorie.Comedie, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<Abonne>());
        mockRepo.Setup(r => r.LoadProjections()).Returns(new ReadOnlyCollection<Projection>(new List<Projection>()));

        // Act
        var result = service.IsFilmEnSalle(film);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsFilmEnSalleShouldReturnFalseWhenRepoReturnsNull()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryProjections>();
        var service = new ServiceProjections(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Titre", 120, DateTime.Now, EnumCategorie.Comedie, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<Abonne>());
        mockRepo.Setup(r => r.LoadProjections()).Returns((ReadOnlyCollection<Projection>)null);

        // Act
        var result = service.IsFilmEnSalle(film);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsFilmEnSalleShouldThrowExceptionWhenRepoThrowsException()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryProjections>();
        var service = new ServiceProjections(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Titre", 120, DateTime.Now, EnumCategorie.Comedie, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<Abonne>());
        mockRepo.Setup(r => r.LoadProjections()).Throws(new Exception("Erreur lors du chargement des projections"));

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => service.IsFilmEnSalle(film));
        Assert.Equal("Erreur lors du chargement des projections", ex.Message);
    }
}