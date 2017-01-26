namespace School.Tests
{
    using NUnit.Framework;
    using Contracts;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class StudentTest
    {
        [Test]
        [TestCase("Gosho", 55256)]
        [TestCase("Misho", 99999)]
        [TestCase("Ivanka", 10000)]
        public void CreateStudent_ShouldCreateObjectFromClassStudentSuccessfully(string name, int id)
        {
            Student student = new Student(name, id);
        }

        [Test]
        public void TestStudent_ToHaveExpectedName()
        {
            string studentName = "Grigor";

            Student student = new Student(studentName, 76567);

            Assert.AreEqual(studentName, student.Name);
        }     

        [Test]
        public void TestStudent_ToHaveExpectedID()
        {
            int studentId = 66674;

            Student student = new Student("Pesho", studentId);

            Assert.AreEqual(studentId, student.ID);
        }

        [Test]
        public void TestStudentName_ToThrowArgumentNullException_IfNameIsNull()
        {
            Student student = new Student("Mitko", 22256);

            Assert.Throws<ArgumentNullException>(() => student.Name = "");
        }

        [Test]
        public void TestStudentID_ToThrowIndexOutOfRangeException_IfIdIsLessThan10000()
        {
            Student student = new Student("Petko", 22256);

            Assert.Throws<IndexOutOfRangeException>(() => student.ID = 8990);
        }

        [Test]
        public void TestStudentID_ToThrowIndexOutOfRangeException_IfIdIsBiggerThan99999()
        {
            Student student = new Student("Maria", 44556);

            Assert.Throws<IndexOutOfRangeException>(() => student.ID = 100000);
        }      
    }
}