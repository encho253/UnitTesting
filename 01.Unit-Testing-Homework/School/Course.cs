namespace School
{
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class Course : ICourse
    {
        private const int MaxStudentsCountInCourse = 30;
        private IList<IStudent> students;
        private string name;

        public Course(string name, IList<IStudent> students)
        {
            this.Name = name;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.name = value;
            }
        }

        public IList<IStudent> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                if (value.Count > MaxStudentsCountInCourse)
                {
                    throw new IndexOutOfRangeException();
                }

                this.students = value;
            }
        }

        public void JoinToCourse(IStudent student)
        {
            if (students.Count > MaxStudentsCountInCourse)
            {
                throw new IndexOutOfRangeException();
            }

            students.Add(student);
        }

        public void LeaveFromCourse(IStudent student)
        {
            if (this.Students.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (this.Students.IndexOf(student) == -1)
            {
                throw new ArgumentException();
            }

            students.Remove(student);
        }
    }
}