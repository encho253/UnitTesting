using Academy.Models;
using Academy.Models.Contracts;
using NUnit.Framework;
using System;

namespace Academy.Tests.ModelsTest.CourseTest
{
    [TestFixture]
    public class EndingDateTest
    {
        [TestCase(null)]
        public void EndingDate_ShouldThrowArgumentException_WhenPassedValueIsInvalid(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new Course("Math", 5, DateTime.Now, DateTime.Parse(value)));
        }

        [TestCase("February 01, 2017")]
        [TestCase("2017/02/26")]
        [TestCase("2017/02/01 18:37:58")]
        [TestCase("2017 - 02 - 10")]
        public void EndingDate_ShouldNotThrowException_WhenPassedValueIsValid(string value)
        {
            Assert.DoesNotThrow(() => new Course("Math", 5, DateTime.Now, DateTime.Parse(value)));
        }

        [TestCase("February 01, 2017")]
        [TestCase("2017/02/26")]
        [TestCase("2017/02/01 18:37:58")]
        [TestCase("2017 - 02 - 10")]
        public void EndingDate_ShouldCorrectlyAssignPassedValue(string value)
        {
            //Arrange
            ICourse course = new Course("Math", 5, DateTime.Now, DateTime.Parse(value));

            //Act and Assert
            Assert.AreEqual(DateTime.Parse(value), course.EndingDate);
        }
    }
}