using Academy.Models;
using Academy.Models.Contracts;
using NUnit.Framework;
using System;

namespace Academy.Tests.ModelsTest.CourseTest
{
    [TestFixture]
    public class NameTest
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("pe")]
        [TestCase("dsfdsfdsfdsfdsfdsfdsfdsfdsfsdfdsfsdfsfshgfhgdsfdsf")]
        public void Name_ShouldThrowArgumentException_WhenPassedValueIsInvalid(string value)
        {
            Assert.Throws<ArgumentException>(() => new Course(value, 5, DateTime.Now, DateTime.Today));
        }

        [TestCase("Math")]
        [TestCase("Phisics")]
        [TestCase("Chemistry")]
        public void Name_ShouldNotThrowException_WhenPassedValueIsTrue(string value)
        {
            Assert.DoesNotThrow(() => new Course(value, 5, DateTime.Now, DateTime.Today));
        }

        [TestCase("Math")]
        [TestCase("Phisics")]
        [TestCase("Chemistry")]
        public void Name_ShouldCorrectlyAssign_PassedValues(string value)
        {
            //Arrange
            ICourse course = new Course(value, 5, DateTime.Now, DateTime.Today);
            string name = value;

            //Act and Assert
            Assert.AreEqual(course.Name, name);
        }
    }
}