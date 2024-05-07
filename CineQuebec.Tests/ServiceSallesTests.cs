using System.Collections.ObjectModel;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services;
using MongoDB.Bson;
using Moq;

namespace CineQuebec.Tests;

public class ServiceSallesTests
{
    [Fact]
    public void GetSallesShouldReturnSalles()
    {
        // Arrange
        var mockRepo = new Mock<IRepositorySalles>();
        var service = new ServiceSalles(mockRepo.Object);
        var salles = new ReadOnlyCollection<Salle>(new List<Salle>
        {
            new Salle(ObjectId.GenerateNewId(), "Salle1", 25),
            new Salle(ObjectId.GenerateNewId(), "Salle2", 50)
        });
        mockRepo.Setup(r => r.LoadSalles()).Returns(salles);
        
        // Act
        var result = service.GetSalles();
        
        // Assert
        Assert.Equal(salles, result);
    }
    [Fact]
    public void GetSallesShouldReturnEmptyWhenNoSalles()
    {
        // Arrange
        var mockRepo = new Mock<IRepositorySalles>();
        var service = new ServiceSalles(mockRepo.Object);
        var salles = new ReadOnlyCollection<Salle>(new List<Salle>());
        mockRepo.Setup(r => r.LoadSalles()).Returns(salles);
    
        // Act
        var result = service.GetSalles();
    
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetSallesShouldReturnNullWhenRepoReturnsNull()
    {
        // Arrange
        var mockRepo = new Mock<IRepositorySalles>();
        var service = new ServiceSalles(mockRepo.Object);
        mockRepo.Setup(r => r.LoadSalles()).Returns((ReadOnlyCollection<Salle>)null);
    
        // Act
        var result = service.GetSalles();
    
        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetSallesShouldThrowExceptionWhenRepoThrowsException()
    {
        // Arrange
        var mockRepo = new Mock<IRepositorySalles>();
        var service = new ServiceSalles(mockRepo.Object);
        mockRepo.Setup(r => r.LoadSalles()).Throws(new Exception());
    
        // Act & Assert
        Assert.Throws<Exception>(() => service.GetSalles());
    }
}
