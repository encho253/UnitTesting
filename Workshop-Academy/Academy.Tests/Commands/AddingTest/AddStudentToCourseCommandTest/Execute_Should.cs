using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace Academy.Tests.Commands.AddingTest.AddStudentToCourseCommandTest
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void ThrowArgumentException_WhenPassedCourseFormIsInvalid()
        {
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            var studentMock = new Mock<IStudent>();
            var seasonMock = new Mock<ISeason>();
            var courseMock = new Mock<ICourse>();

            studentMock.SetupGet(x => x.Username).Returns("Pesho");
            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

            seasonMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.SetupGet(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            courseMock.SetupGet(x => x.OnlineStudents).Returns(new List<IStudent>() { studentMock.Object });
            seasonMock.SetupGet(x => x.Courses).Returns(new List<ICourse>() { courseMock.Object });

            var addStudentToCourse = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            var parameters = new List<string>() { "Pesho", "0", "0", "no valid form" };

            //Act and Assert
            Assert.Throws<ArgumentException>(() => addStudentToCourse.Execute(parameters));
        }

        [Test]
        public void AddCorrectlyStudentIntoTheCourseInTheCorespondingAttendanceForm_WhenPassedCourseFormIsOnsite()
        {
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            var studentMock = new Mock<IStudent>();
            var seasonMock = new Mock<ISeason>();
            var courseMock = new Mock<ICourse>();

            studentMock.SetupGet(x => x.Username).Returns("Pesho");
            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

            seasonMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.SetupGet(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            courseMock.SetupGet(x => x.OnsiteStudents).Returns(new List<IStudent>() { studentMock.Object });
            seasonMock.SetupGet(x => x.Courses).Returns(new List<ICourse>() { courseMock.Object });


            var addStudentToCourse = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            var parameters = new List<string>() { "Pesho", "0", "0", "onsite" };
          
            //Act
            addStudentToCourse.Execute(parameters);

            //Assert
            Assert.AreEqual(2 , courseMock.Object.OnsiteStudents.Count);
        }

        [Test]
        public void AddCorrectlyStudentIntoTheCourseInTheCorespondingAttendanceForm_WhenPassedCourseFormIsOnlie()
        {
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            var studentMock = new Mock<IStudent>();
            var seasonMock = new Mock<ISeason>();
            var courseMock = new Mock<ICourse>();

            studentMock.SetupGet(x => x.Username).Returns("Pesho");
            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

            seasonMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.SetupGet(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            courseMock.SetupGet(x => x.OnlineStudents).Returns(new List<IStudent>() { studentMock.Object });
            seasonMock.SetupGet(x => x.Courses).Returns(new List<ICourse>() { courseMock.Object });


            var addStudentToCourse = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            var parameters = new List<string>() { "Pesho", "0", "0", "online" };

            //Act
            addStudentToCourse.Execute(parameters);

            //Assert
            Assert.AreEqual(2, courseMock.Object.OnlineStudents.Count);
        }

        [Test]
        public void ReturnSuccessMessageThatContainsStudentUserNameAndSeason()
        {
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            var studentMock = new Mock<IStudent>();
            var seasonMock = new Mock<ISeason>();
            var courseMock = new Mock<ICourse>();

            studentMock.SetupGet(x => x.Username).Returns("Pesho");
            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

            seasonMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.SetupGet(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            courseMock.SetupGet(x => x.OnsiteStudents).Returns(new List<IStudent>() { studentMock.Object });
            seasonMock.SetupGet(x => x.Courses).Returns(new List<ICourse>() { courseMock.Object });


            var addStudentToCourse = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            var parameters = new List<string>() { "Pesho", "0", "0", "onsite" };

            //Act
            var result = addStudentToCourse.Execute(parameters);

            //Assert
            StringAssert.Contains("Pesho", result);
            StringAssert.Contains("0",result);
        }
    }
}