namespace School.Contracts
{
    using System.Collections.Generic;

    public interface ICourse
    {
        IData Students { get; }

        string Name { get; }

        void JoinToCourse(IStudent student);

        void LeaveFromCourse(IStudent student);
    }
}