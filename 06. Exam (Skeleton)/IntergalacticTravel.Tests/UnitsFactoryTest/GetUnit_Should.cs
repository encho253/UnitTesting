using IntergalacticTravel.Exceptions;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.UnitsFactoryTest
{
    [TestFixture]
    public class GetUnit_Should
    {
        [Test]
        public void ReturnNewProcyonUnit_WhenValidCorrespondingCommandIsPassed()
        {
            //Arrange
            var unitFactory = new UnitsFactory();

            //Act
            var result = unitFactory.GetUnit("create unit Procyon Gosho 1");

            //Assert
            Assert.IsInstanceOf<Procyon>(result);
        }


        [Test]
        public void ReturnNewProcyonLuyten_WhenValidCorrespondingCommandIsPassed()
        {
            //Arrange
            var unitFactory = new UnitsFactory();

            //Act
            var result = unitFactory.GetUnit("create unit Luyten Pesho 2");

            //Assert
            Assert.IsInstanceOf<Luyten>(result);
        }

        [Test]
        public void ReturnNewProcyonLacaille_WhenValidCorrespondingCommandIsPassed()
        {
            //Arrange
            var unitFactory = new UnitsFactory();

            //Act
            var result = unitFactory.GetUnit("create unit Lacaille Tosho 3");

            //Assert
            Assert.IsInstanceOf<Lacaille>(result);
        }

        [TestCase("invalid command")]
        [TestCase("")]
        public void ThrowInvalidUnitCreationCommandException_WhenValidCorrespondingCommandIsInvalid(string value)
        {
            //Arrange
            var unitFactory = new UnitsFactory();


            //Act and Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => unitFactory.GetUnit(value));
        }
    }    
}