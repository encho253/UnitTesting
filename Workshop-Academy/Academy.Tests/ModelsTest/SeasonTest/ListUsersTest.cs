using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Moq;
using NUnit.Framework;

namespace Academy.Tests.ModelsTest.SeasonTest
{
    [TestFixture]
    public class ListUsersTest
    {
        [Test]
        public void ListUser_ShouldReturnAListOfTrainers()
        {
            //Arrange
            ISeason season = new Season(2016, 2016, Initiative.KidsAcademy);
            var trainerMock = new Mock<ITrainer>();
            trainerMock.Setup(x => x.ToString());

            season.Trainers.Add(trainerMock.Object);

            //Act
            season.ListUsers();

            //Assert
            trainerMock.Verify(x => x.ToString(), Times.Exactly(1));
        }

        [Test]
        public void ListUser_ShouldReturnAListOfStudents()
        {
            //Arrange
            ISeason season = new Season(2016, 2016, Initiative.KidsAcademy);
            var studentMock = new Mock<IStudent>();
            studentMock.Setup(x => x.ToString());

            season.Students.Add(studentMock.Object);

            //Act
            season.ListUsers();

            //Assert
            studentMock.Verify(x => x.ToString(), Times.Exactly(1));
        }

        [TestCase("There are no users in this season!")]
        public void ListUser_ShouldReturnMessage_SayingThatThereAreNoCoursesInThisSeason(string value)
        {
            //Arrange
            ISeason season = new Season(2016, 2017, Initiative.CoderDojo);

            //Act and Assert
            Assert.AreEqual(season.ListUsers(), value);
        }
    }
}