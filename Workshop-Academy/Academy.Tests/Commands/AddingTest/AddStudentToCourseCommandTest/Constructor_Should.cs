using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Tests.Commands.AddingTest.Fake;
using Moq;
using NUnit.Framework;
using System;

namespace Academy.Tests.Commands.AddingTest.AddStudentToCourseCommandTest
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenFactoryIsNull()
        {
            //Arrange
            var engineStub = new Mock<IEngine>();

            //Act and Assert 
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(null, engineStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenEngineIsNull()
        {
            //Arrange
            var factoryStub = new Mock<IAcademyFactory>();

            //Act and Assert 
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(factoryStub.Object, null));
        }

        [Test]
        public void CorrectlyAssignPassedEngine()
        {
            //Arrange
            var engineStub = new Mock<IEngine>();
            var factoryStub = new Mock<IAcademyFactory>();

            //Act
            var addStudentToCourseFake = new AddStudentToCourseCommandFake(factoryStub.Object, engineStub.Object);

            //Assert
            Assert.AreSame(engineStub.Object, addStudentToCourseFake.Engine);
        }

        [Test]
        public void CorrectlyAssignPassedFactory()
        {
            //Arrange
            var engineStub = new Mock<IEngine>();
            var factoryStub = new Mock<IAcademyFactory>();

            //Act
            var addStudentToCourseFake = new AddStudentToCourseCommandFake(factoryStub.Object, engineStub.Object);

            //Assert
            Assert.AreSame(factoryStub.Object, addStudentToCourseFake.Factory);
        }
    }
}