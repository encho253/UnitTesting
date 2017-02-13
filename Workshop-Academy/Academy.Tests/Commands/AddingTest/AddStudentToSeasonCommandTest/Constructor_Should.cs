using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Tests.Commands.AddingTest.Fake;
using Moq;
using NUnit.Framework;
using System;

namespace Academy.Tests.Commands.AddingTest.AddStudentToSeasonCommandTest
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenFactoryIsNull()
        {
            //Arrange
            Mock<IEngine> engineStub = new Mock<IEngine>();

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(null, engineStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenEngineIsNull()
        {
            //Arrange
            Mock<IAcademyFactory> factoryStub = new Mock<IAcademyFactory>();

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(factoryStub.Object, null));
        }

        [Test]
        public void CorrectlySetFactory_WhenPassedValuesIsNotNull()
        {
            //Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            //Act
            var addStudentFake = new AddStudentToSeasonCommandFake(factoryStub.Object, engineStub.Object);

            //Assert
            Assert.AreSame(factoryStub.Object, addStudentFake.Factory);
        }

        [Test]
        public void CorrectlySetEngine_WhenPassedValuesIsNotNull()
        {
            //Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            //Act
            var addStudentFake = new AddStudentToSeasonCommandFake(factoryStub.Object, engineStub.Object);

            //Assert
            Assert.AreSame(engineStub.Object, addStudentFake.Engine);
        }

        [Test]
        public void CorrectlyAssignPassedValues()
        {
            //Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            //Act
            var addStudentFake = new AddStudentToSeasonCommandFake(factoryStub.Object, engineStub.Object);

            //Assert
            Assert.AreSame(factoryStub.Object, addStudentFake.Factory);
        }
    }
}