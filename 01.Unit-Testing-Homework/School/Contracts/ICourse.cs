namespace School.Contracts
{
    using System.Collections.Generic;

    public interface ICourse
    {
        IList<IStudent> Students { get; set; }
        string Name { get; set; }

        void JoinToCourse(IStudent student);
        void LeaveFromCourse(IStudent student);
    }
}