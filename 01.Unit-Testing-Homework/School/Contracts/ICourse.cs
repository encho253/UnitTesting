namespace School.Contracts
{
    using System.Collections.Generic;

    public interface ICourse
    {
        IList<IStudent> Students { get; set; }
    }
}