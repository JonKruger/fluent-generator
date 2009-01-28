using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Expressions;
using FluentGenerator.MyGeneration.Plugin;
using StructureMap;

namespace FluentGenerator.Example
{
    public class SampleGenerator : Generator
    {
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

            RunMyGenerationTemplate(new Dictionary<string, object> { { "1", "hello" } }, 
                @"c:\proj\fluent-generator\SampleMygenerationtemplate.csgen", @"c:\temp\output.cs");
        }
    }
}
