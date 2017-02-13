using Academy.Models.Abstractions;

namespace Academy.Tests.ModelsTest.AbstractionsTest.Fake
{
    public class UserFake : User
    {
        public UserFake(string username) 
            : base(username)
        {
        }
    }
}