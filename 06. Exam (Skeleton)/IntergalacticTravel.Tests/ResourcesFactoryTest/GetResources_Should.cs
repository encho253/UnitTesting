using IntergalacticTravel.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace IntergalacticTravel.Tests.ResourcesFactoryTest
{
    [TestFixture]
    public class GetResources_Should
    {
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void ReturnANewlyCreatedResourcesObjectWithCorrectlySetUpProperties(string command)
        {
            //Arrange
            var factory = new ResourcesFactory();
            var gold = 20;
            var silver = 30;
            var bronze = 40;

            //Act
            var result = factory.GetResources(command);

            //Assert
            Assert.AreEqual(gold, result.GoldCoins);
            Assert.AreEqual(silver, result.SilverCoins);
            Assert.AreEqual(bronze, result.BronzeCoins);
        }

        [TestCase("create resources  x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("dsfdsfdsfdsfs")]
        public void ThrowInvalidOperationException_WhichContainsTheStringCommand_WhenTheInputStringRepresentsAnInvalidCommand(string command)
        {
            //Arrange
            var factory = new ResourcesFactory();

            //Act and Assert
            Assert.Throws<InvalidOperationException>(() => factory.GetResources(command));
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void ThrowOverflowException_WhenTheInputStringCommandIsInTheCorrectFormat_ButAnyOfTheValuesThatRepresentTheResourceMmountIsLargerThanUint_MaxValue(string command)
        {
            //Arrange
            var factory = new ResourcesFactory();

            //Act and Assert
            Assert.Throws<OverflowException>(() => factory.GetResources(command));
        }
    }
}