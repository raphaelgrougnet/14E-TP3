using System.Collections.ObjectModel;
using CineQuebec.Windows.DAL.Interfaces;
using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;

namespace CineQuebec.Tests
{
    public class ServicePreferenceTest
    {
        [Fact]
        public void TestLoadActeurs_Success()
        {
            // Arrange
            var mockRepo = new Mock<IRepositoryActeur>();
            var service = new ServiceActeur(mockRepo.Object);
            
            ReadOnlyCollection<Acteur> acteurs = new ReadOnlyCollection<Acteur>(new List<Acteur>{ new Acteur(ObjectId.GenerateNewId(), "Oui"), new Acteur(ObjectId.GenerateNewId(), "Non") });
            mockRepo.Setup(r => r.LoadActeurs()).Returns(acteurs);

            // Act
            var result = service.LoadActeurs();

            // Assert
            Assert.Equal(acteurs.Count, result.Count);
            for (int i = 0; i < acteurs.Count; i++)
            {
                Assert.Equal(acteurs[i].Nom, result[i].Nom);
            }
        }

        [Fact]
        public void TestLoadActeurs_ThrowsException()
        {
            // Arrange
            var mockRepo = new Mock<IRepositoryActeur>();
            var service = new ServiceActeur(mockRepo.Object);

            mockRepo.Setup(r => r.LoadActeurs()).Throws(new Exception());

            // Act & Assert
            Assert.Throws<Exception>(() => service.LoadActeurs());
        }

        [Fact]
        public void TestLoadActeurs_RepoReturnsEmptyList_ReturnsEmptyList()
        {
            // Arrange
            var mockRepo = new Mock<IRepositoryActeur>();
            var service = new ServiceActeur(mockRepo.Object);

            var acteurs = new ReadOnlyCollection<Acteur>(new List<Acteur>());
            mockRepo.Setup(r => r.LoadActeurs()).Returns(acteurs);

            // Act
            var result = service.LoadActeurs();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void TestLoadDirecteur_Success()
        {
            // Arrange
            var mockRepo = new Mock<IRepositoryDirecteur>();
            var service = new ServiceDirecteur(mockRepo.Object);

            ReadOnlyCollection<Directeur> directeur = new ReadOnlyCollection<Directeur>(new List<Directeur> { new Directeur(ObjectId.GenerateNewId(), "Oui"), new Directeur(ObjectId.GenerateNewId(), "Non") });
            mockRepo.Setup(r => r.LoadDirecteurs()).Returns(directeur);

            // Act
            var result = service.LoadDirecteurs();

            // Assert
            Assert.Equal(directeur.Count, directeur.Count);
            for (int i = 0; i < directeur.Count; i++)
            {
                Assert.Equal(directeur[i].Nom, directeur[i].Nom);
            }
        }

        [Fact]
        public void TestLoadDirecteur_EmptyList()
        {
            // Arrange
            var mockRepo = new Mock<IRepositoryDirecteur>();
            var service = new ServiceDirecteur(mockRepo.Object);

            ReadOnlyCollection<Directeur> directeur = new ReadOnlyCollection<Directeur>(new List<Directeur>());
            mockRepo.Setup(r => r.LoadDirecteurs()).Returns(directeur);

            // Act
            var result = service.LoadDirecteurs();

            // Assert
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void TestLoadDirecteur_ThrowsException()
        {
            // Arrange
            var mockRepo = new Mock<IRepositoryDirecteur>();
            var service = new ServiceDirecteur(mockRepo.Object);

            mockRepo.Setup(r => r.LoadDirecteurs()).Throws(new Exception());

            // Act & Assert
            Assert.Throws<Exception>(() => service.LoadDirecteurs());
        }

        [Fact]
        public void TestLoadRealisateur_Success()
        {
            // Arrange
            var mockRepo = new Mock<IRepositoryRealisateur>();
            var service = new ServiceRealisateur(mockRepo.Object);

            ReadOnlyCollection<Realisateur> realisateur = new ReadOnlyCollection<Realisateur>(new List<Realisateur> { new Realisateur(ObjectId.GenerateNewId(), "Oui"), new Realisateur(ObjectId.GenerateNewId(), "Non") });
            mockRepo.Setup(r => r.LoadRealisateurs()).Returns(realisateur);

            // Act
            var result = service.LoadRealisateurs();

            // Assert
            Assert.Equal(realisateur.Count, result.Count);
            for (int i = 0; i < realisateur.Count; i++)
            {
                Assert.Equal(realisateur[i].Nom, result[i].Nom);
            }
        }

        [Fact]
        public void TestLoadRealisateur_ThrowsException()
        {
            // Arrange
            var mockRepo = new Mock<IRepositoryRealisateur>();
            var service = new ServiceRealisateur(mockRepo.Object);

            mockRepo.Setup(r => r.LoadRealisateurs()).Throws(new Exception());

            // Act & Assert
            Assert.Throws<Exception>(() => service.LoadRealisateurs());
        }

        [Fact]
        public void TestLoadRealisateur_RepoReturnsEmptyList_ReturnsEmptyList()
        {
            // Arrange
            var mockRepo = new Mock<IRepositoryRealisateur>();
            var service = new ServiceRealisateur(mockRepo.Object);

            var realisateur = new ReadOnlyCollection<Realisateur>(new List<Realisateur>());
            mockRepo.Setup(r => r.LoadRealisateurs()).Returns(realisateur);

            // Act
            var result = service.LoadRealisateurs();

            // Assert
            Assert.Empty(result);
        }
    }
}
