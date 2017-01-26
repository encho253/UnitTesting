namespace School
{
    using global::School.Contracts;
    using System;
    using System.Collections.Generic;

    public class Course : ICourse
    {
        private IList<IStudent> students;

        public Course(IList<IStudent> students)
        {
            this.Students = students;
        }

        public IList<IStudent> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                if (value.Count > 30)
                {
                    throw new IndexOutOfRangeException();
                }

                this.students = value;
            }
        }
    }
}