using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Service;

namespace FluentGenerator
{
    public class FluentGeneratorRegistry : StructureMap.Configuration.DSL.Registry
    {
        protected override void configure()
        {
            base.configure();

            ForRequestedType<IFileSystemService>().TheDefaultIsConcreteType<FileSystemService>();
            ForRequestedType<ICodeWriter>().TheDefaultIsConcreteType<CodeWriter>();
            ForRequestedType<IGeneratorFactory>().TheDefaultIsConcreteType<GeneratorFactory>();
            ForRequestedType<IMyGenerationService>().TheDefaultIsConcreteType<MyGenerationService>();
            ForRequestedType<IMyGenerationService>().TheDefaultIsConcreteType<MyGenerationService>();
            ForRequestedType<IMessageBoxService>().TheDefaultIsConcreteType<MessageBoxService>();
        }
    }
}
