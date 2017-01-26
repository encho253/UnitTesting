namespace School.Tests
{
    using NUnit.Framework;
    using Contracts;
    using System;
    using System.Text;

    [TestFixture]
    public class CourseTest
    {
        [Test]
        public void CreateCourse_ShouldCreateObjectFromClassCourseSuccessfully()
        {
            ICourse course = new Course("Math");
        }

        [Test]
        public void TestCourse_ToHaveExpectedName()
        {
            ICourse course = new Course("Math");
            string courseName = "Math";

            Assert.AreEqual(courseName, course.Name);
        }

        [Test]
        public void TestCourse_TryToSetCourseNameWithEmptyString_ExpectedArgumentNullException()
        {
            ICourse course = new Course("Math");

            Assert.Throws<ArgumentNullException>(() => new Course(""));
        }

        [Test]
        public void GetStudents_ShouldReadStudentsFromCourseSuccessfully()
        {
            IStudent student = new Student("Pesho", 22445);
            ICourse course = new Course("Phisic");
            StringBuilder builder = new StringBuilder();

            course.JoinToCourse(student);

            foreach (var item in course.Students)
            {
                builder.AppendLine(item.ToString());
            }
        }

        [Test]
        public void JoinToCourse_ShouldAddStudentToCourseSuccessfully_IfStudentIsNotNull_AndStudentsAreLessThan30InThisCourse()
        {
            Student studentPenko = new Student("Penko", 22225);

            ICourse course = new Course("Yoga");

            course.JoinToCourse(studentPenko);
        }

        [Test]
        public void LeaveFromCourse_ShouldLeaveStudentFromCourseSuccessfully_IfStudentIsNotNull()
        {
            Student student = new Student("Gana", 99999);

            ICourse course = new Course("Math");

            course.LeaveFromCourse(student);
        }

        [Test]
        public void TestCourseLimit_ShouldCreateCourseSuccessfully_With30Students()
        {
            Course course = new Course("Math");

            for (int i = 0; i <= 30; i++)
            {
                Student student = new Student("Pesho", 10000 + i);

                course.JoinToCourse(student);
            }
        }

        [Test]
        public void TestCourseLimit_ToThrowIndexOutOfRangeException_IfStudentsInCourseAreBiggerThan30()
        {
            Course course = new Course("Math");
            Student studentPesho = new Student("Pesho", 10000);

            for (int i = 0; i <= 30; i++)
            {
                Student student = new Student("Gosho", 10000 + i);

                course.JoinToCourse(student);
            }

            Assert.Throws<IndexOutOfRangeException>(() => course.JoinToCourse(studentPesho));
        }
    }
}
