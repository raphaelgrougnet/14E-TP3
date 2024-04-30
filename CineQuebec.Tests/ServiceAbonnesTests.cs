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
        public void UdpdateAbonneShouldReturnUpdatedAbonne()
        {
            // Arrange
            var mockRepository = new Mock<IRepositoryAbonnes>();
            var service = new ServiceAbonnes(mockRepository.Object);
            var abonne = new Mock<IAbonne>();
            mockRepository.Setup(x => x.UpdateAbonne(abonne.Object)).Returns(abonne.Object);

            //Act
            var result = service.UpdateAbonne(abonne.Object);

            //Assert
            Assert.Equal(abonne.Object, result);


        }
    }
}
