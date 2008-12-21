using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator.Example
{
    public class SampleGenerator : Generator
    {
        public override void Generate()
        {
            using (new OutputFile(@"Driver.cs"))
            {
                CreateClass("Driver")
                    .AddProperty("Name").OfType("string")
                    .AddProperty("Address").OfType("string")
                    .AddListOf("Truck").WithName("Trucks");

                CreateClass("Truck")
                    .FromDatabaseTable("Trucks");
            }
        }

    }
}
