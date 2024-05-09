using System.Collections.ObjectModel;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services;
using MongoDB.Bson;
using Moq;

namespace CineQuebec.Tests
{
    public class ServiceRecompenseTests
    {
        [Fact]
        public void AddUneRecompenseAUnAbonneShouldReturnTrueWhenAddSucceeds()
        {
            // Arrange
            var mockRepository = new Mock<IRepositoryRecompense>();
            var serviceRecompense = new ServiceRecompense(mockRepository.Object);
            var id = new ObjectId("5f8f4b3b7b3e6f0b7c7b3e6f");
            var recompense = new Recompense(ObjectId.GenerateNewId(), "Test", EnumType.TicketGratuit, "Merci de votre participation", 30 ,id);

            mockRepository.Setup(x => x.AddRecompenseToAbonne(recompense)).Returns(true);

            // Act
            var result = serviceRecompense.AddRecompenseToAbonne(recompense);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddUneRecompenseAUnAbonneShouldReturnFalseWhenAddFails()
        {
            // Arrange
            var mockRepository = new Mock<IRepositoryRecompense>();
            var serviceRecompense = new ServiceRecompense(mockRepository.Object);
            var id = new ObjectId("5f8f4b3b7b3e6f0b7c7b3e6f");
            var recompense = new Recompense(ObjectId.GenerateNewId(), "Test", EnumType.TicketGratuit, "Merci de votre participation", 30, id);

            mockRepository.Setup(x => x.AddRecompenseToAbonne(recompense)).Returns(false);

            // Act
            var result = serviceRecompense.AddRecompenseToAbonne(recompense);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void AddUneRecompenseAUnAbonneShouldThrowExceptionWhenRepositoryThrowsException()
        {
            // Arrange
            var mockRepository = new Mock<IRepositoryRecompense>();
            var serviceRecompense = new ServiceRecompense(mockRepository.Object);
            var id = new ObjectId("5f8f4b3b7b3e6f0b7c7b3e6f");
            var recompense = new Recompense(ObjectId.GenerateNewId(), "Test", EnumType.TicketGratuit, "Merci de votre participation", 30, id);

            mockRepository.Setup(x => x.AddRecompenseToAbonne(recompense)).Throws<Exception>();

            // Act & Assert
            Assert.Throws<Exception>(() => serviceRecompense.AddRecompenseToAbonne(recompense));
        }

        [Fact]
        public void TestDecrementerNombreRestant_WithPositiveNumber()
        {
            // Arrange
            var id = new ObjectId("5f8f4b3b7b3e6f0b7c7b3e6f");
            var recompense = new Recompense("Test", EnumType.TicketGratuit, "Test Description", 5, id);

            // Act
            var result = recompense.DecrementerNombreRestant();

            // Assert
            Assert.True(result);
            Assert.Equal((uint)4, recompense.NombreRestant);
        }

        [Fact]
        public void TestDecrementerNombreRestant_WithZero()
        {
            // Arrange
            var id = new ObjectId("5f8f4b3b7b3e6f0b7c7b3e6f");
            var recompense = new Recompense("Test", EnumType.TicketGratuit, "Test Description", 0, id);

            // Act
            var result = recompense.DecrementerNombreRestant();

            // Assert
            Assert.False(result);
            Assert.Equal((uint)0, recompense.NombreRestant);
        }
    }
}
