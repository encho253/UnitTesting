using Academy.Models;
using Academy.Models.Contracts;
using NUnit.Framework;
using System;

namespace Academy.Tests.ModelsTest.CourseTest
{
    [TestFixture]
    public class StartingDateTest
    {
        [TestCase(null)]
        public void StartingDate_ShouldThrowArgumentNullException_WhenPassedValueIsInvalid(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new Course("Math", 5, DateTime.Parse(value), DateTime.Now));
        }

        [TestCase("February 01, 2017")]
        [TestCase("2017/02/26")]
        [TestCase("2017/02/01 18:37:58")]
        [TestCase("2017 - 02 - 10")]
        public void StartingDate_ShouldNotThrow_WhenPassedValueIsValid(string value)
        {
            Assert.DoesNotThrow(() => new Course("Math", 5, DateTime.Parse(value), DateTime.Now));
        }

        [TestCase("February 01, 2017")]
        [TestCase("2017/02/26")]
        [TestCase("2017/02/01 18:37:58")]
        [TestCase("2017 - 02 - 10")]
        public void StartingDate_ShouldCorrectlyAssignPassedValue(string value)
        {
            //Arrange
            ICourse course = new Course("Math", 5, DateTime.Parse(value), DateTime.Now);

            //Act and Assert
            Assert.AreEqual(DateTime.Parse(value), course.StartingDate);
        }
    }
}