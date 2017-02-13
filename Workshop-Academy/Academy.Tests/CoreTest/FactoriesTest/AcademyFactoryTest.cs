using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Models.Utils.LectureResources;
using NUnit.Framework;
using System;

namespace Academy.Tests.CoreTest.FactoriesTest
{
    [TestFixture]
    public class AcademyFactoryTest
    {
        [Test]
        public void CreateLectureResource_ShouldThrowArgumentException_WhenPassedTypeIsInvalid()
        {
            //Arrange
            var anInstance = AcademyFactory.Instance;

            //Act and Assert
            Assert.Throws<ArgumentException>(() => anInstance.CreateLectureResource("pesho", "Pesho", "www.pesho.com"));
        }

        [Test]
        public void CreateLectureResource_ShouldReturnCorrectInstancesOfVideo()
        {
            //Arrange
            var anInstance = AcademyFactory.Instance;

            //Act
            var actualValue = anInstance.CreateLectureResource("video", "Pesho", "www.pesho.com");

            //Assert
            Assert.IsInstanceOf<VideoResource>(actualValue);
        }

        [Test]
        public void CreateLectureResource_ShouldReturnCorrectInstancesOfPresentation()
        {
            //Arrange
            var anInstance = AcademyFactory.Instance;

            //Act
            var actualValue = anInstance.CreateLectureResource("presentation", "Pesho", "www.pesho.com");

            //Assert
            Assert.IsInstanceOf<PresentationResource>(actualValue);
        }

        [Test]
        public void CreateLectureResource_ShouldReturnCorrectInstancesOfDemo()
        {
            //Arrange
            var anInstance = AcademyFactory.Instance;

            //Act
            var actualValue = anInstance.CreateLectureResource("demo", "Pesho", "www.pesho.com");

            //Assert
            Assert.IsInstanceOf<DemoResource>(actualValue);
        }

        [Test]
        public void CreateLectureResource_ShouldReturnCorrectInstancesOfHomework()
        {
            //Arrange
            var anInstance = AcademyFactory.Instance;

            //Act
            var actualValue = anInstance.CreateLectureResource("homework", "Pesho", "www.pesho.com");

            //Assert
            Assert.IsInstanceOf<HomeworkResource>(actualValue);
        }
    }
}
