using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Tests.ModelsTest.AbstractionsTest.Fake;
using Moq;
using NUnit.Framework;
using System;

namespace Academy.Tests.ModelsTest.AbstractionsTest
{
    [TestFixture]
    public class UserTest
    {
        [Test]
        public void Constuctor_ShouldCorrectlyAssignPassedValue()
        {
            //Arrange and act
            var value = "Pesho";
            var userFake = new UserFake(value);

            Assert.AreEqual(value, userFake.Username);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("pe")]
        [TestCase("fdsfdsfdsfdsfdsfsfdsfsdfdsfsdfds")]
        public void Username_ShouldThrowArgumenException_WhenPassedValueIsInvalid(string value)
        {
            Assert.Throws<ArgumentException>(() => new UserFake(value));
        }

        [TestCase("Pesho")]
        [TestCase("Samuil")]
        public void Username_ShouldNotThrowArgumentException_WhenPassedValueIsValid(string value)
        {
            Assert.DoesNotThrow(() => new UserFake(value));
        }
    }
}