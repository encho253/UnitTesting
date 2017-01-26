namespace School.Tests
{
    using NUnit.Framework;
    using Contracts;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void CreateStudent_ShouldCreateObjectFromClassStudentSuccessfully()
        {
            Student student = new Student("Goshka", 22555);
        }

        [Test]
        public void CreateCourse_ShouldCreateObjectFromClassCourseSuccessfully()
        {
            Student student = new Student("Goshka", 22555);

            IList<IStudent> students = new List<IStudent>();

            ICourse course = new Course(students);
        }
        [Test]
        public void JoinToCourse_ShouldAddStudentToCourseSuccessfully_IfStudentIsNotNull_AndStudentsAreLessThan30InThisCourse()
        {
            Student student = new Student("Goshka", 22555);

            IList<IStudent> students = new List<IStudent>();

            ICourse course = new Course(students);

            student.JoinToCourse(course);
        }

        [Test]
        public void LeaveFromCourse_ShouldLeaveStudentFromCourseSuccessfully_IfStudentIsNotNull()
        {
            Student student = new Student("Goshka", 22555);

            IList<IStudent> students = new List<IStudent>();

            ICourse course = new Course(students);

            student.LeaveFromCourse(course);
        }
    }
}