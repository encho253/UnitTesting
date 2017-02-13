using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Moq;
using NUnit.Framework;

namespace Academy.Tests.ModelsTest.SeasonTest
{
    [TestFixture]
    public class ListCoursesTest
    {
        [Test]
        public void ListCourses_ShouldReturnAListOfCourses_OnlyCheckIfTheMethodIteratesOverTheCollection()
        {
            //Arrange
            ISeason season = new Season(2016, 2017, Initiative.SchoolAcademy);
            var courseMock = new Mock<ICourse>();

            courseMock.Setup(x => x.ToString());
            season.Courses.Add(courseMock.Object);

            //Act
            season.ListCourses();

            //Assert
            courseMock.Verify(x => x.ToString(), Times.Once);
        }

        [TestCase("There are no courses in this season!")]
        public void ListCourses_ShouldReturnMessage_SayingThatThereAreNoCoursesInThisSeason(string value)
        {
            //Arrange
            ISeason season = new Season(2016, 2017, Initiative.SchoolAcademy);

            //Act and Assert
            Assert.AreEqual(season.ListCourses(), value);
        }
    }
}