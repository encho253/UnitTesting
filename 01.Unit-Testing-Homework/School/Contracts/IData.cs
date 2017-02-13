namespace School.Contracts
{
    public interface IData
    {
        void Add(IStudent student);

        void Remove(IStudent student);

        int Count();
    }
}