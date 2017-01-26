namespace School.Contracts
{
    public interface IStudent
    {
        string Name { get; set; }

        int ID { get; set; }  

        void JoinToCourse(ICourse course);

        void LeaveFromCourse(ICourse course);
    }
}
