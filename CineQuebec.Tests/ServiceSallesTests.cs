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
}
