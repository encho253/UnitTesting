using Academy.Commands.Adding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Core.Contracts;

namespace Academy.Tests.Commands.AddingTest.Fake
{
    internal class AddStudentToCourseCommandFake : AddStudentToCourseCommand
    {
        public AddStudentToCourseCommandFake(IAcademyFactory factory, IEngine engine) 
            : base(factory, engine)
        {
        }

        public IEngine Engine
        {
            get
            {
                return this.engine;
            }
        }

        public IAcademyFactory Factory
        {
            get
            {
                return this.factory;
            }
        }
    }
}