﻿namespace School
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
                else if (value.GroupBy(x => x.ID).Any(g => g.Count() > 1))
                {
                    throw new ArgumentException();
                }

                this.students = value;
            }
        }

        public void JoinToCourse(IStudent student)
        {
            if (students.Count > MaxStudentsCountInCourse)
            {
                throw new IndexOutOfRangeException("All places,for this course,are occupied!");
            }
            else if (this.Students.GroupBy(x => x.ID).Any(y => y.Key == student.ID))
            {
                throw new ArgumentException("Student with same ID already exist"); 
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