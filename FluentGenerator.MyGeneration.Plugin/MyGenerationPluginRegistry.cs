using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;

namespace FluentGenerator.MyGeneration.Plugin
{
    public class MyGenerationPluginRegistry : Registry
    {
        protected override void configure()
        {
            base.configure();

            ForRequestedType<IMyGenerationDataBroker>().TheDefaultIsConcreteType<MyGenerationDataBroker>();
        }
    }
}
