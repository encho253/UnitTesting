using Academy.Models;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Academy.Tests.ModelsTest.CourseTest
{
    [TestFixture]
    public class ConstructorTest
    {
        [Test]
        public void Constructor_ShouldCorrectlyAssignPassedName()
        {
            //Act and Arrange
            var passedName = "Math";
            var course = new Course(passedName, 5, DateTime.Today, DateTime.Now);

            //Assert
            Assert.AreEqual(passedName, course.Name);
        }

        [Test]
        public void Constructor_ShouldCorrectlyAssignPassedStartingDate()
        {
            //Act and Arrange
            var passedDate = DateTime.Parse("2017.05.05");
            var course = new Course("Math", 5, passedDate, DateTime.Now);

            //Assert
            Assert.AreEqual(passedDate, course.StartingDate);
        }

        [Test]
        public void Constructor_ShouldCorrectlyAssignPassedEndingDate()
        {
            //Act and Arrange
            var passedDate = DateTime.Parse("2017.05.05");
            var course = new Course("Math", 5,DateTime.Now, passedDate);

            //Assert
            Assert.AreEqual(passedDate, course.EndingDate);
        }

        [Test]
        public void Constructor_ShouldCorrectlyInitializeTheCollection_OnlineStudents()
        {
            //Arrange
            ICourse course = new Course("Math", 5, DateTime.Today, DateTime.Now);

            //Act and Assert
            Assert.IsNotNull(course.OnlineStudents);
        }

        [Test]
        public void Constructor_ShouldCorrectlyInitializeTheCollection_OnsiteStudents()
        {
            //Arrange
            ICourse course = new Course("Math", 5, DateTime.Today, DateTime.Now);

            //Act and Assert
            Assert.IsNotNull(course.OnsiteStudents);
        }

        [Test]
        public void Constructor_ShouldCorrectlyInitializeTheCollection_Lectures()
        {
            //Arrange
            ICourse course = new Course("Math", 5, DateTime.Today, DateTime.Now);

            //Act and Assert
            Assert.IsNotNull(course.Lectures);
        }
    }
}