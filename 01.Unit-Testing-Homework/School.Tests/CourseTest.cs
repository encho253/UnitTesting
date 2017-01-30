namespace School.Tests
{
    using NUnit.Framework;
    using Contracts;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class CourseTest
    {
        [Test]
        public void TestCourse_ToHaveExpectedName()
        {
            IStudent student = new Student("Pesho", 88991);
            IList<IStudent> students = new List<IStudent>();
            ICourse course = new Course("Math", students);

            string courseName = "Math";

            Assert.AreEqual(courseName, course.Name);
        }

        [Test]
        public void TestCourse_TryToSetCourseNameWithEmptyString_ExpectedArgumentNullException()
        {
            IStudent student = new Student("Pesho", 88991);
            IList<IStudent> students = new List<IStudent>();
            ICourse course = new Course("Math", students);

            Assert.Throws<ArgumentNullException>(() => course.Name = "");
        }
        [Test]
        public void JoinToCourse_ShouldAddStudentToCourseSuccessfully_WitoutThrowException()
        {
            IStudent student = new Student("Pesho", 88991);
            IList<IStudent> students = new List<IStudent>();

            ICourse course = new Course("Math", students);

            Assert.DoesNotThrow(() => course.JoinToCourse(student));
        }

        [Test]
        public void LeaveFromCourse_ShouldStudentLeaveFromCourseSuccessfully_WitoutThrowException()
        {
            IStudent student = new Student("Pesho", 88991);
            IList<IStudent> students = new List<IStudent>();
            students.Add(student);
            ICourse course = new Course("Math", students);

            Assert.DoesNotThrow(() => course.LeaveFromCourse(student));
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
        public void TestCourseLimit_IfCourseContainSetOfStudents_WithCountBiggerThan30_ToThrowIndexOutOfRangeException()
        {
            IList<IStudent> students = new List<IStudent>();

            for (int i = 0; i <= 30; i++)
            {
                IStudent student = new Student("Gosho", 10000 + i);

                students.Add(student);
            }

            Assert.Throws<IndexOutOfRangeException>(() => new Course("Math", students));
        }

        [Test]
        public void TestCourseIDUnique_IfCourseContainTwoOrMoreStudentsWithEqualID_ToThrowArgumentException()
        {
            IList<IStudent> students = new List<IStudent>();
            IStudent pesho = new Student("Pesho",10000);
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
            ICourse course = new Course("Phisic",students);

            Assert.Throws<ArgumentException>(() => course.JoinToCourse(gosho));
        }
    }
}
