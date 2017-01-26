namespace School.Contracts
{
    using System.Collections.Generic;

    public interface ICourse
    {
        IList<IStudent> Students { get; }
        string Name { get; }

        void JoinToCourse(IStudent student);
        void LeaveFromCourse(IStudent student);
    }
}