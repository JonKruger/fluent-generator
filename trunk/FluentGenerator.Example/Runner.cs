using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentGenerator.Tests;
using StructureMap;

namespace FluentGenerator.Example
{
    public class Runner
    {
        public void Generate()
        {
            new SampleGenerator().Generate();
        }
    }
}
