using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Academy.Tests.Commands.AddingTest.AddStudentToSeasonCommandTest
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void Execute_ShouldThrowArgumentException_WhenThePassedStudentIsAlreadyAPartOfThatSeason()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Pesho", "0" };
            var factoryStub = new Mock<IAcademyFactory>();
            var mockedEngine = new Mock<IEngine>();
            var mockedStudent = new Mock<IStudent>();
            var mockedSeason = new Mock<ISeason>();

            mockedStudent.SetupGet(x => x.Username).Returns("Pesho");
            mockedEngine.SetupGet(x => x.Students).Returns(new List<IStudent>() { mockedStudent.Object });

            mockedSeason.SetupGet(x => x.Students).Returns(new List<IStudent>() { mockedStudent.Object });
            mockedEngine.SetupGet(x => x.Seasons).Returns(new List<ISeason>() { mockedSeason.Object });


            var addStudent = new AddStudentToSeasonCommand(factoryStub.Object, mockedEngine.Object);


            //Act and Assert
            Assert.Throws<ArgumentException>(() => addStudent.Execute(parameters));
        }

        [Test]
        public void Execute_ShouldCorrectlyAddStudentToSeason_WhenThePassedStudentIsNotAPartOfThatSeason()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Pesho", "0" };
            var factoryStub = new Mock<IAcademyFactory>();
            var mockedEngine = new Mock<IEngine>();
            var mockedStudent = new Mock<IStudent>();
            var mockedSeason = new Mock<ISeason>();

            mockedStudent.SetupGet(x => x.Username).Returns("Pesho");
            mockedEngine.SetupGet(x => x.Students).Returns(new List<IStudent>() { mockedStudent.Object });

            var anotherMockStudent = new Mock<IStudent>();
            anotherMockStudent.SetupGet(x => x.Username).Returns("Another Pesho");

            var studentsInSeason = new List<IStudent>() { anotherMockStudent.Object };

            mockedSeason.SetupGet(x => x.Students).Returns(studentsInSeason);
            mockedEngine.SetupGet(x => x.Seasons).Returns(new List<ISeason>() { mockedSeason.Object });


            var addStudent = new AddStudentToSeasonCommand(factoryStub.Object, mockedEngine.Object);


            //Act
            var result = addStudent.Execute(parameters);

            //Assert
            Assert.AreEqual(mockedSeason.Object.Students.Count, 2);
        }

        [Test]
        public void Execute_ShouldReturnASuccessMassageThatContainsStudentUsernameAndSeasonId()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Pesho", "0" };
            var factoryStub = new Mock<IAcademyFactory>();
            var mockedEngine = new Mock<IEngine>();
            var mockedStudent = new Mock<IStudent>();
            var mockedSeason = new Mock<ISeason>();

            mockedStudent.SetupGet(x => x.Username).Returns("Pesho");
            mockedEngine.SetupGet(x => x.Students).Returns(new List<IStudent>() { mockedStudent.Object });

            var anotherMockStudent = new Mock<IStudent>();
            anotherMockStudent.SetupGet(x => x.Username).Returns("Another Pesho");

            var studentsInSeason = new List<IStudent>() { anotherMockStudent.Object };

            mockedSeason.SetupGet(x => x.Students).Returns(studentsInSeason);
            mockedEngine.SetupGet(x => x.Seasons).Returns(new List<ISeason>() { mockedSeason.Object });


            var addStudent = new AddStudentToSeasonCommand(factoryStub.Object, mockedEngine.Object);


            //Act
            var result = addStudent.Execute(parameters);

            //Assert
            StringAssert.Contains("Pesho", result);
            StringAssert.Contains("Season 0", result);
        }
    }
}
