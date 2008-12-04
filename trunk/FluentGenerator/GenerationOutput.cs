using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator
{
    public class GenerationOutput : IGenerationOutput
    {
        public object Output
        {
            get; private set;
        }

        public GenerationOutput(object output)
        {
            Output = output;
        }
    }
}
