namespace School
{
    using global::School.Contracts;
    using System;

    public class Student : IStudent
    {
        private string name;
        private int id;

        public Student(string name, int id)
        {
            this.Name = name;
            this.ID = id;
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

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value < 10000 && value > 99999)
                {
                    throw new IndexOutOfRangeException();
                }

                this.id = value;
            }
        }

        public void JoinToCourse(ICourse course)
        {
            course.Students.Add(this);
        }

        public void LeaveFromCourse(ICourse course)
        {
            course.Students.Remove(this);
        }
    }
}