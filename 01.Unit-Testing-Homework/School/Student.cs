namespace School
{
    using global::School.Contracts;
    using System;

    public class Student : IStudent
    {
        private const int MinIDLenght = 10000;
        private const int MaxIDLenght = 99999;

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
                if (value < MinIDLenght || value > MaxIDLenght)
                {
                    throw new IndexOutOfRangeException();
                }

                this.id = value;
            }
        }      
    }
}