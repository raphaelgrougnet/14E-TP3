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
        public void UpdateAbonneShouldReturnUpdatedAbonne()
        {
            // Arrange
            var mockRepository = new Mock<IRepositoryAbonnes>();
            var service = new ServiceAbonnes(mockRepository.Object);
            var id = new ObjectId("5f8f4b3b7b3e6f0b7c7b3e6f"); 

            var preferences = new Preference(id, new List<Acteur>(), new List<Realisateur>(), new List<Directeur>(), new List<EnumCategorie>());
            preferences.Acteurs.Add(new Acteur("Albert"));
            preferences.Realisateurs.Add(new Realisateur("Bob"));
            preferences.Directeurs.Add(new Directeur("Charlie"));
            preferences.Categories.Add(EnumCategorie.Comedie);

            mockRepository.Setup(x => x.UpdateAbonne(id, preferences)).Returns(true);

            //Act
            var result = service.UpdateAbonne(id, preferences);

            //Assert
            Assert.True(result);


        }
    }
}
