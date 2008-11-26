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
                    .WithPropertyChanging()
                    .WithPropertyChanged()
                    .AddPrimaryKeyProperty("DriverId")
                    .AddProperty<string>("Name")
                    .AddProperty<string>("Address")
                    .AddListOf("Truck").WithName("Trucks");

                CreateClass("Truck")
                    .WithPropertyChanging()
                    .WithPropertyChanged()
                    .FromDatabaseTable("Trucks");
            }
        }

    }
}
