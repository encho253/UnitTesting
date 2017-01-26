namespace School
{
    using global::School.Contracts;
    using System;
    using System.Collections.Generic;

    public class Course : ICourse
    {
        private const int MaxStudentsCountInCourse = 30;
        private IList<IStudent> students;
        private string name;

        public Course(string name)
        {
            this.Name = name;
            students = new List<IStudent>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
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
            students.Remove(student);
        }
    }
}