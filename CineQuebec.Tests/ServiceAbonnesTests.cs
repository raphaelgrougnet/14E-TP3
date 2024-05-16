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

        [Fact]
        public void AjouterRealisateur_AddsRealisateurToPreferences()
        {
            // Arrange
            byte[] password = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            byte[] salt = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            Preference preference = new Preference(ObjectId.GenerateNewId(), new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<EnumCategorie>());
            var abonne = new Abonne(ObjectId.GenerateNewId(), "Beaumont", "Lou", "Lapinou", "lou@gmail.com", password, salt, preference, new List<Film>(), new List<Film>());
            ObjectId id = ObjectId.GenerateNewId();
            var realisateur = new Realisateur(id, "Junior");

            // Act
            abonne.AjouterRealisateur(realisateur);

            // Assert
            Assert.Contains(realisateur, abonne.Preferences.Realisateurs);
        }

        [Fact]
        public void AjouterCategorie_AddsCategorieToPreferences()
        {
            // Arrange
            byte[] password = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            byte[] salt = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            Preference preference = new Preference(ObjectId.GenerateNewId(), new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<EnumCategorie>());
            var abonne = new Abonne(ObjectId.GenerateNewId(), "Beaumont", "Lou", "Lapinou", "lou@gmail.com", password, salt, preference, new List<Film>(), new List<Film>());
            var categorie = EnumCategorie.Action;

            // Act
            abonne.AjouterCategorie(categorie);

            // Assert
            Assert.Contains(categorie, abonne.Preferences.Categories);
        }

        [Fact]
        public void AjouterDirecteur_AddsDirecteurToPreferences()
        {
            // Arrange
            byte[] password = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            byte[] salt = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            Preference preference = new Preference(ObjectId.GenerateNewId(), new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<EnumCategorie>());
            var abonne = new Abonne(ObjectId.GenerateNewId(), "Beaumont", "Lou", "Lapinou", "lou@gmail.com", password, salt, preference, new List<Film>(), new List<Film>());
            ObjectId id = ObjectId.GenerateNewId();
            var directeur = new Directeur(id, "Lapinou");

            // Act
            abonne.AjouterDirecteur(directeur);

            // Assert
            Assert.Contains(directeur, abonne.Preferences.Directeurs);
        }

        [Fact]
        public void AjouterActeur_AddsActeurToPreferences()
        {
            // Arrange
            byte[] password = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            byte[] salt = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            Preference preference = new Preference(ObjectId.GenerateNewId(), new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<EnumCategorie>());
            var abonne = new Abonne(ObjectId.GenerateNewId(), "Beaumont", "Lou", "Lapinou", "lou@gmail.com", password, salt, preference, new List<Film>(), new List<Film>());
            ObjectId id = ObjectId.GenerateNewId();

            var acteur = new Acteur(id, "Koko");

            // Act
            abonne.AjouterActeur(acteur);

            // Assert
            Assert.Contains(acteur, abonne.Preferences.Acteurs);
        }
    }
}
