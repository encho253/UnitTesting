using Academy.Models;
using NUnit.Framework;
using System;

namespace Academy.Tests.ModelsTest.CourseTest
{
    [TestFixture]
    public class LecturesPerWeekTest
    {
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-15)]
        [TestCase(8)]
        [TestCase(12)]
        public void LecturesPerWeek_ShouldThrowArgumentException_WhenPassedValueIsInvalid(int value)
        {
            Assert.Throws<ArgumentException>(() => new Course("Math", value, DateTime.Today, DateTime.Now));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(6)]
        [TestCase(7)]
        public void LecturesPerWeek_ShouldNotThrowException_WhenPassedValueIsValid(int value)
        {
            Assert.DoesNotThrow(() => new Course("Math", value, DateTime.Today, DateTime.Now));
        }
    }
}