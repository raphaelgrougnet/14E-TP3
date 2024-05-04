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
        var film = new Film(ObjectId.GenerateNewId(), "Titre", 120, DateTime.Now, EnumCategorie.Comedie, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>());
        var salle = new Salle(ObjectId.GenerateNewId(), "Salle", 25); 
        var projection = new Projection(ObjectId.GenerateNewId(), salle, DateTime.Now, new Film(ObjectId.GenerateNewId(), "Titre", 120, DateTime.Now, EnumCategorie.Comedie, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>()));
        mockRepo.Setup(r => r.AddProjection(It.IsAny<Projection>())).Returns(projection);
        
        // Act
        var result = service.ProgrammerReprojection(film, salle);
        
        // Assert
        Assert.Equal(projection, result);
    }
    
    [Fact]
    public void LoadProjectionsShouldReturnProjections()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryProjections>();
        var service = new ServiceProjections(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Titre", 120, DateTime.Now, EnumCategorie.Comedie, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>());
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
    public void IsFilmEnSalleShouldReturnTrue()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryProjections>();
        var service = new ServiceProjections(mockRepo.Object);
        var film = new Film(ObjectId.GenerateNewId(), "Titre", 120, DateTime.Now, EnumCategorie.Comedie, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>());
        var salle = new Salle(ObjectId.GenerateNewId(), "Salle", 25);
        var projection = new Projection(ObjectId.GenerateNewId(), salle, DateTime.Now, film);
        var projections = new ReadOnlyCollection<Projection>(new List<Projection>{projection});
        mockRepo.Setup(r => r.LoadProjections()).Returns(projections);
        
        // Act
        var result = service.IsFilmEnSalle(film);
        
        // Assert
        Assert.True(result);
    }
}