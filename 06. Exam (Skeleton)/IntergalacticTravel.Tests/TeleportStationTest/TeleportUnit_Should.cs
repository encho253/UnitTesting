using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using IntergalacticTravel.Tests.TeleportStationTest.Fake;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests.TeleportStationTest
{
    [TestFixture]
    public class TeleportUnit_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUnitToTeleportIsNull()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var targetLocation = new Mock<ILocation>();

            var expectedMessage = "unitToTeleport";

            var galacticMap = new List<IPath>();

            var teleportStation = new TeleportStation(ownerMock.Object, galacticMap, locationMock.Object);

            //Act and Assert
            var actualMessage = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(null, targetLocation.Object));
            StringAssert.Contains(expectedMessage, actualMessage.Message);
        }


        [Test]
        public void ThrowArgumentNullException_WhenLocationToTeleportIsNull()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var expectedMessage = "destination";

            var galacticMap = new List<IPath>();

            var teleportStation = new TeleportStation(ownerMock.Object, galacticMap, locationMock.Object);

            //Act and Assert
            var actualMessage = Assert.Throws<ArgumentNullException>(() => teleportStation.TeleportUnit(unitToTeleportMock.Object, null));
            StringAssert.Contains(expectedMessage, actualMessage.Message);
        }

        [Test]
        public void ThrowTeleportOutOfRangeException_WhenAUnitTryToUseTeleportStationFromDistantLocation()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocation = new Mock<ILocation>();

            var galaxyName = "Milky Way";
            var planetName = "Venera";
            var differentGalaxyName = "Any way";
            var differentPlanetName = "Mars";

            var expectedMessage = "unitToTeleport.CurrentLocation";
            var galacticMap = new List<IPath>();

            locationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            locationMock.Setup(x => x.Planet.Name).Returns(planetName);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(differentGalaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(differentPlanetName);

            var teleportStation = new TeleportStation(ownerMock.Object, galacticMap, locationMock.Object);

            //Act and Assert
            var actualMessage = Assert.Throws<TeleportOutOfRangeException>(() => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocation.Object));
            StringAssert.Contains(expectedMessage, actualMessage.Message);
        }

        [Test]
        public void ThrowLocationNotFoundException_WhenTryingToTeleportAUnitToGalaxyWhichIsNotFoundALocationListOfTeleportStation()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocation = new Mock<ILocation>();

            var galaxyName = "Milky Way";
            var planetName = "Venera";

            var expectedMessage = "Galaxy";
            var galacticMap = new List<IPath>();

            locationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            locationMock.Setup(x => x.Planet.Name).Returns(planetName);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);

            var teleportStation = new TeleportStation(ownerMock.Object, galacticMap, locationMock.Object);

            //Act and Assert
            var actualMessage = Assert.Throws<LocationNotFoundException>(() => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocation.Object));
            StringAssert.Contains(expectedMessage, actualMessage.Message);
        }

        [Test]
        public void ThrowLocationNotFoundException_WhenTryingToTeleportAUnitToPlanetWhichIsNotFoundALocationListOfTeleportStation()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();

            var galaxyName = "Milky Way";
            var planetName = "Venera";

            var expectedMessage = "Planet";
            var galacticMap = new List<IPath>();

            locationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            locationMock.Setup(x => x.Planet.Name).Returns(planetName);

            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);

            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);

            galacticMap.Add(pathMock.Object);

            var teleportStation = new TeleportStation(ownerMock.Object, galacticMap, locationMock.Object);

            //Act and Assert
            var actualMessage = Assert.Throws<LocationNotFoundException>(() => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));
            StringAssert.Contains(expectedMessage, actualMessage.Message);
        }

        [Test]
        public void ThrowInvalidTeleportationLocationException_WhenTryingToTeleportAUnitToLocationWhichAnotherUnitHAsAlreadyTaken()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();

            var galaxyName = "Milky Way";
            var planetName = "Venera";
            var longtitude = 30.5;
            var latitude = 20.5;

            var expectedMessage = "units will overlap";
            var galacticMap = new List<IPath>();
            var unitCollection = new List<IUnit>();

            locationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            locationMock.Setup(x => x.Planet.Name).Returns(planetName);

            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);

            unitCollection.Add(unitToTeleportMock.Object);

            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(unitCollection);

            galacticMap.Add(pathMock.Object);

            var teleportStation = new TeleportStation(ownerMock.Object, galacticMap, locationMock.Object);

            //Act and Assert
            var actualMessage = Assert.Throws<InvalidTeleportationLocationException>(() => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));
            StringAssert.Contains(expectedMessage, actualMessage.Message);
        }

        [Test]
        public void ThrowInsufficientResourcesException_WhenTryingToTeleportAUnitToAGivenLocationButTheServiceCostsMoreThanTheUnitCurrentAvailableResources()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();

            var galaxyName = "Milky Way";
            var planetName = "Venera";
            var longtitude = 30.5;
            var latitude = 20.5;
            var anotherLongtitude = 40.5;
            var anotherLatitude = 20.5;

            var expectedMessage = "FREE LUNCH";
            var galacticMap = new List<IPath>();
            var unitCollection = new List<IUnit>();

            locationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            locationMock.Setup(x => x.Planet.Name).Returns(planetName);

            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(anotherLongtitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(anotherLatitude);

            unitCollection.Add(unitToTeleportMock.Object);

            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(unitCollection);

            galacticMap.Add(pathMock.Object);

            var teleportStation = new TeleportStation(ownerMock.Object, galacticMap, locationMock.Object);

            //Act and Assert
            var actualMessage = Assert.Throws<InsufficientResourcesException>(() => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));
            StringAssert.Contains(expectedMessage, actualMessage.Message);
        }

        [Test]
        public void RequireAPaymentFromTheUnitToTeleportForTheProvidedServices_WhenAllOfTheValidationsPassSuccessfullyAndTheUnitIsReadyForTeleportation()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();
            var resourceMock = new Mock<IResources>();

            var galaxyName = "Milky Way";
            var planetName = "Venera";
            var longtitude = 30.5;
            var latitude = 20.5;
            var anotherLongtitude = 40.5;
            var anotherLatitude = 20.5;
            uint bronz = 15;
            uint silver = 12;
            uint gold = 10;

            var galacticMap = new List<IPath>();
            var unitCollection = new List<IUnit>();

            locationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            locationMock.Setup(x => x.Planet.Name).Returns(planetName);

            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);

            resourceMock.Setup(x => x.BronzeCoins).Returns(bronz);
            resourceMock.Setup(x => x.SilverCoins).Returns(silver);
            resourceMock.Setup(x => x.GoldCoins).Returns(gold);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(anotherLongtitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(anotherLatitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(resourceMock.Object)).Returns(resourceMock.Object);
            unitCollection.Add(unitToTeleportMock.Object);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(unitCollection);

            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(unitCollection);
            pathMock.Setup(x => x.Cost).Returns(resourceMock.Object);

            galacticMap.Add(pathMock.Object);

            var teleportStationFake = new TeleportStationFake(ownerMock.Object, galacticMap, locationMock.Object);

            //Act
            teleportStationFake.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);

            //Assert
            unitToTeleportMock.Verify(x => x.Pay(resourceMock.Object), Times.Exactly(1));
        }

        [Test]
        public void ObtainAPaymentFromTheUnitToTeleportForTheProvidedServices_TheAmountOfResourcesOfTheTeleportStationMustBeIncreasedByTheAmountOfThePayment()
        {
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();
            var resourceMock = new Mock<IResources>();

            var galaxyName = "Milky Way";
            var planetName = "Venera";
            var longtitude = 30.5;
            var latitude = 20.5;
            var anotherLongtitude = 40.5;
            var anotherLatitude = 20.5;
            uint bronz = 10;
            uint silver = 10;
            uint gold = 10;

            var galacticMap = new List<IPath>();
            var unitCollection = new List<IUnit>();

            locationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            locationMock.Setup(x => x.Planet.Name).Returns(planetName);

            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);

            resourceMock.Setup(x => x.BronzeCoins).Returns(bronz);
            resourceMock.Setup(x => x.SilverCoins).Returns(silver);
            resourceMock.Setup(x => x.GoldCoins).Returns(gold);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(anotherLongtitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(anotherLatitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(resourceMock.Object)).Returns(resourceMock.Object);
            unitCollection.Add(unitToTeleportMock.Object);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(unitCollection);

            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(unitCollection);
            pathMock.Setup(x => x.Cost).Returns(resourceMock.Object);

            galacticMap.Add(pathMock.Object);

            var teleportStationFake = new TeleportStationFake(ownerMock.Object, galacticMap, locationMock.Object);

            var expectedGold = teleportStationFake.Resources.GoldCoins + resourceMock.Object.GoldCoins;
            var expectedSilver = teleportStationFake.Resources.SilverCoins + resourceMock.Object.SilverCoins;
            var expectedBrozne = teleportStationFake.Resources.BronzeCoins + resourceMock.Object.BronzeCoins;

            //Act
            teleportStationFake.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);
            var actualGold = teleportStationFake.Resources.GoldCoins;
            var actualSilver = teleportStationFake.Resources.SilverCoins;
            var actualBronze = teleportStationFake.Resources.BronzeCoins;

            //Assert
            Assert.AreEqual(expectedGold, actualGold);
            Assert.AreEqual(expectedSilver, actualSilver);
            Assert.AreEqual(expectedBrozne, actualBronze);
        }


        [Test]
        public void SetTheUnitToTeleportPreviousLocationToUnitToTeleportCurrentLocation_WhenAllOfTheValidationsPassSuccessfullyAndTheUnitIsBeingTeleported()
        { 
            //Arrange
            var ownerMock = new Mock<IBusinessOwner>();
            var locationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();
            var pathMock = new Mock<IPath>();
            var resourceMock = new Mock<IResources>();

            var galaxyName = "Milky Way";
            var planetName = "Venera";
            var longtitude = 30.5;
            var latitude = 20.5;
            var anotherLongtitude = 40.5;
            var anotherLatitude = 20.5;
            uint bronz = 10;
            uint silver = 10;
            uint gold = 10;

            var galacticMap = new List<IPath>();
            var unitCollection = new List<IUnit>();

            locationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            locationMock.Setup(x => x.Planet.Name).Returns(planetName);

            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);

            resourceMock.Setup(x => x.BronzeCoins).Returns(bronz);
            resourceMock.Setup(x => x.SilverCoins).Returns(silver);
            resourceMock.Setup(x => x.GoldCoins).Returns(gold);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(anotherLongtitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(anotherLatitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(resourceMock.Object)).Returns(resourceMock.Object);
            unitCollection.Add(unitToTeleportMock.Object);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(unitCollection);

            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(unitCollection);
            pathMock.Setup(x => x.Cost).Returns(resourceMock.Object);

            galacticMap.Add(pathMock.Object);

            var teleportStationFake = new TeleportStationFake(ownerMock.Object, galacticMap, locationMock.Object);

            var expectedGold = teleportStationFake.Resources.GoldCoins + resourceMock.Object.GoldCoins;
            var expectedSilver = teleportStationFake.Resources.SilverCoins + resourceMock.Object.SilverCoins;
            var expectedBrozne = teleportStationFake.Resources.BronzeCoins + resourceMock.Object.BronzeCoins;

            //Act
            teleportStationFake.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);
            var actualGold = teleportStationFake.Resources.GoldCoins;
            var actualSilver = teleportStationFake.Resources.SilverCoins;
            var actualBronze = teleportStationFake.Resources.BronzeCoins;

            //Assert
            Assert.AreEqual(expectedGold, actualGold);
            Assert.AreEqual(expectedSilver, actualSilver);
            Assert.AreEqual(expectedBrozne, actualBronze);
        }
    }
}