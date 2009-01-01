using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Expressions;
using StructureMap;

namespace FluentGenerator.Example
{
    public class SampleGenerator : Generator
    {
        static SampleGenerator()
        {
            ObjectFactory.Initialize(x => x.AddRegistry<FluentGeneratorRegistry>());
        }

        public override void Generate()
        {
            using (new OutputFile(@"c:\temp\Driver.cs"))
            {
                Namespace("TestNamespace");

                CreateClass("Driver")
                    .AddProperty("Name").OfType("string")
                    .AddProperty("Address").OfType("string")
                    .AddListOf("Truck").WithName("Trucks");

                //CreateClass("Truck")
                //    .FromDatabaseTable("Trucks");
            }
        }
    }
}
