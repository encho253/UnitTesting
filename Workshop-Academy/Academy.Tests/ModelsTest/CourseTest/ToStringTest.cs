using Academy.Models;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Academy.Tests.ModelsTest.CourseTest
{
    [TestFixture]
    public class ToStringTest
    {
        [Test]
        public void ToString_Should()
        {
            //Arrange
            var course = new Course("Math", 5, DateTime.Now, DateTime.Now);
            var mockedLecture = new Mock<ILecture>();

            mockedLecture.Setup(x => x.ToString());
            course.Lectures.Add(mockedLecture.Object);

            //Act
            course.ToString();

            //Assert
            mockedLecture.Verify(x => x.ToString(), Times.Once);
        }
    }
}