using System;
using System.Collections.Generic;
using School.Contracts;
using System.Linq;

namespace School
{
    public class StudentsCollection : IData
    {
        public StudentsCollection(ICollection<IStudent> students)
        {
            this.Students = students;
        }

        public ICollection<IStudent> Students
        {
            get
            {
                return this.Students;
            }

            set
            {
                if (value.GroupBy(x => x.ID).Any(g => g.Key > 1))
                {
                    throw new ArgumentException("Have repeated ID");
                }

                this.Students = value;
            }
        }

        public void Add(IStudent student)
        {        
            if (this.Students.GroupBy(x => x.ID).Any(y => y.Key == student.ID))
            {
                throw new ArgumentException("Student with same ID already exist");
            }

            this.Students.Add(student);
        }

        public void Remove(IStudent student)
        {
            this.Students.Remove(student);
        }

        public int Count()
        {
            return this.Students.Count;
        }
    }
}