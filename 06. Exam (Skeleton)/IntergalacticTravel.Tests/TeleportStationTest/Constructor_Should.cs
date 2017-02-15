using IntergalacticTravel.Contracts;
using IntergalacticTravel.Tests.TeleportStationTest.Fake;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests.TeleportStationTest
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldSetUpOwner_WhenANewTeleportStationIscreatedWithValidParametersPassedToTheConstructor()
        {
            //Arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var locationStub = new Mock<ILocation>();
            var galacticMap = new List<IPath>();

            var expectedOwner = ownerStub.Object;

            //Act
            var teleportStatition = new TeleportStationFake(ownerStub.Object, galacticMap, locationStub.Object);
            var actualOwner = teleportStatition.Owner;

            //Assert
            Assert.AreSame(expectedOwner, actualOwner);
        }

        [Test]
        public void ShouldSetUpGalacticMap_WhenANewTeleportStationIscreatedWithValidParametersPassedToTheConstructor()
        {
            //Arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var locationStub = new Mock<ILocation>();
            var galacticMap = new List<IPath>();

            var expectedGalacticMap = galacticMap;
      
            //Act
            var teleportStatition = new TeleportStationFake(ownerStub.Object, galacticMap, locationStub.Object);
            var actualLocation = teleportStatition.GalacticMap;

            //Assert
            Assert.AreSame(expectedGalacticMap, actualLocation);
        }

        [Test]
        public void ShouldSetUpLocation_WhenANewTeleportStationIscreatedWithValidParametersPassedToTheConstructor()
        {
            //Arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var locationStub = new Mock<ILocation>();
            var galacticMap = new List<IPath>();

            var expectedLocation = locationStub.Object;

            //Act
            var teleportStatition = new TeleportStationFake(ownerStub.Object, galacticMap, locationStub.Object);
            var actualGalacticMap = teleportStatition.Location;

            //Assert
            Assert.AreSame(expectedLocation, actualGalacticMap);
        }
    }
}