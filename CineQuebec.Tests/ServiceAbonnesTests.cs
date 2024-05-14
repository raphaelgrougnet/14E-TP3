using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.Services;
using CineQuebec.Windows.Domain;
using MongoDB.Bson;

namespace CineQuebec.Tests
{
    public class ServiceAbonnesTests
    {
        [Fact]
        public void UpdateAbonneShouldReturnTrueWhenUpdateSucceeds()
        {
            // Arrange
            var mockRepository = new Mock<IRepositoryAbonnes>();
            var service = new ServiceAbonnes(mockRepository.Object);
            var id = new ObjectId("5f8f4b3b7b3e6f0b7c7b3e6f");
            var preferences = new Preference(id, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<EnumCategorie>());

            mockRepository.Setup(x => x.UpdateAbonne(id, preferences)).Returns(true);

            // Act
            var result = service.UpdateAbonne(id, preferences);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateAbonneShouldReturnFalseWhenUpdateFails()
        {
            // Arrange
            var mockRepository = new Mock<IRepositoryAbonnes>();
            var service = new ServiceAbonnes(mockRepository.Object);
            var id = new ObjectId("5f8f4b3b7b3e6f0b7c7b3e6f");
            var preferences = new Preference(id, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<EnumCategorie>());

            mockRepository.Setup(x => x.UpdateAbonne(id, preferences)).Returns(false);

            // Act
            var result = service.UpdateAbonne(id, preferences);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void UpdateAbonneShouldThrowExceptionWhenUpdateThrowsException()
        {
            // Arrange
            var mockRepository = new Mock<IRepositoryAbonnes>();
            var service = new ServiceAbonnes(mockRepository.Object);
            var id = new ObjectId("5f8f4b3b7b3e6f0b7c7b3e6f");
            var preferences = new Preference(id, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<EnumCategorie>());

            mockRepository.Setup(x => x.UpdateAbonne(id, preferences)).Throws<Exception>();

            // Act & Assert
            Assert.Throws<Exception>(() => service.UpdateAbonne(id, preferences));
        }
    }
}
