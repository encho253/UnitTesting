namespace School.Tests
{
    using NUnit.Framework;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using Moq;
    using System.Collections;

    [TestFixture]
    public class CourseTest
    {
        [TestCase("Phisics")]
        [TestCase("Math")]
        public void TestCourse_ToHaveExpectedName(string value)
        {
            //Arrange and Act
            ICourse course = new Course(value, new List<IStudent>());

            //Assert
            Assert.AreEqual(value, course.Name);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("    ")]
        public void TestCourse_TryToSetCourseNameWithNullReference_ExpectedArgumentNullException(string value)
        {
            //Arrange, Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Course(value, new List<IStudent>()));
        }
      
        [Test]
        public void TestCourseLimit_IfStudentsInCourseAreBiggerThan30_ToThrowIndexOutOfRangeException()
        {
            IList<IStudent> students = new List<IStudent>();
            ICourse course = new Course("Math", students);
            IStudent pesho = new Student("Pesho", 44467);

            for (int i = 0; i <= 30; i++)
            {
                IStudent student = new Student("Gosho", 10000 + i);

                course.JoinToCourse(student);
            }

            Assert.Throws<IndexOutOfRangeException>(() => course.JoinToCourse(pesho));
        }

        [Test]
        public void JoinToCourse_ShouldCallMethod_ExpectedTimes()
        {
            //Arrange
            Mock<IStudent> mockedStudent = new Mock<IStudent>();
            Mock<IList> asdsa = new Mock<IList>();

            //Act

            //Assert          
        }

        [Test]
        public void JoinToCourse_ShouldAddStudentToCourseSuccessfully_WithOutThrowException()
        {
            //Arrange
            Mock<IStudent> mockedStudent = new Mock<IStudent>();
            Mock<ICourse> mockedCourse = new Mock<ICourse>();

            //Act
            mockedCourse.Setup(x => x.JoinToCourse(mockedStudent.Object));

            //Assert

        }

        [Test]
        public void LeaveFromCourse_ShouldCallMethod_ExactlyTimes()
        {
            //Arrange
            Mock<IStudent> mockedStudent = new Mock<IStudent>();
            Mock<ICourse> mockedCourse = new Mock<ICourse>();

            //Act
            mockedCourse.Object.LeaveFromCourse(mockedStudent.Object);

            //Assert
            mockedCourse.Verify(x => x.LeaveFromCourse(It.IsAny<IStudent>()), Times.Exactly(1));
        }

        [Test]
        public void LeaveFromCourse_ShouldNotStudentLeaveFromCourseWhichIsNotRecorded_ExpectedToThrowArgumentException()
        {
            IStudent pesho = new Student("Pesho", 88991);
            IStudent gosho = new Student("Gosho", 55679);
            IList<IStudent> students = new List<IStudent>();
            students.Add(pesho);
            ICourse course = new Course("Math", students);

            Assert.Throws<ArgumentException>(() => course.LeaveFromCourse(gosho));
        }

        [Test]
        public void LeaveFromCourse_ShouldNotStudentLeaveFromEmptyCourse_ExpectedIndexOutOfRangeException()
        {
            IStudent gosho = new Student("Gosho", 55679);
            IList<IStudent> students = new List<IStudent>();
            ICourse course = new Course("Math", students);

            Assert.Throws<IndexOutOfRangeException>(() => course.LeaveFromCourse(gosho));
        }

        [Test]
        public void TestCourseIDUnique_IfCourseContainTwoOrMoreStudentsWithEqualID_ToThrowArgumentException()
        {
            IList<IStudent> students = new List<IStudent>();
            IStudent pesho = new Student("Pesho", 10000);
            IStudent gosho = new Student("Gosho", 10000);

            students.Add(pesho);
            students.Add(gosho);

            Assert.Throws<ArgumentException>(() => new Course("Math", students));
        }

        [Test]
        public void JoinToCourse_ShouldNotAddStudentWithSameID_ExpectedArgumentException()
        {
            IList<IStudent> students = new List<IStudent>();
            IStudent pesho = new Student("Pesho", 10000);
            IStudent gosho = new Student("Gosho", 10000);

            students.Add(pesho);
            ICourse course = new Course("Phisic", students);

            Assert.Throws<ArgumentException>(() => course.JoinToCourse(gosho));
        }
    }
}
