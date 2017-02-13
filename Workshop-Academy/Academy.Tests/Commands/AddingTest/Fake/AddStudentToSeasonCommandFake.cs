using Academy.Commands.Adding;
using Academy.Core.Contracts;

namespace Academy.Tests.Commands.AddingTest.Fake
{
    internal class AddStudentToSeasonCommandFake : AddStudentToSeasonCommand
    {
        public AddStudentToSeasonCommandFake(IAcademyFactory factory, IEngine engine)
            : base(factory, engine)
        {
        }

        public IAcademyFactory Factory
        {
            get
            {
                return this.factory;
            }
        }

        public IEngine Engine
        {
            get
            {
                return this.engine;
            }
        }
    }
}
