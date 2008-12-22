using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentGenerator.Tests;
using StructureMap;

namespace FluentGenerator.Example
{
    [TestFixture]
    public class Runner
    {
        [Test]
        public void Generate()
        {
            new SampleGenerator().Generate();
        }
    }
}
