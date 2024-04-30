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
        var mockRepo = new Mock<IRepositoryProjection>();
        var service = new ServiceProjections(mockRepo.Object);
        var projection = new Projection(ObjectId.GenerateNewId(), "Salle", DateTime.Now, new Film(ObjectId.GenerateNewId(), "Titre", 120, DateTime.Now, EnumCategorie.Comedie, "Acteurs", "Genre", "Directeurs"));
        mockRepo.Setup(r => r.AddProjection(It.IsAny<Projection>())).Returns(projection);
        
        // Act
        var result = service.ProgrammerReprojection(projection);
        
        // Assert
        Assert.Equal(projection, result);
    }
}