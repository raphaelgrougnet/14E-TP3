using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CineQuebec.Windows.DAL;

namespace CineQuebec.Tests
{
    public class ServiceAbonnesTests
    {
        [Fact]
        public void UdpdateAbonneShouldReturnUpdatedAbonne()
        {
            var mockRepository = new Mock<IAbonneRepository>();
        }
    }
}
