using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using FluentGenerator.Service;
using StructureMap;

namespace FluentGenerator.Expressions
{
    public class Generator : GeneratorBase
    {
        private NamespaceExpression _currentNamespace;
        private IMyGenerationService _myGenerationService;

        public Generator(IMyGenerationService myGenerationService, IGeneratorFactory generatorFactory, IFileSystemService fileSystemService) : base(generatorFactory, fileSystemService)
        {
            _myGenerationService = myGenerationService;
        }

        public Generator()
            : base()
        {
            _myGenerationService = ObjectFactory.GetInstance<IMyGenerationService>();
        }

        public ClassExpression CreateClass()
        {
            return CreateClass(null);
        }

        public ClassExpression CreateClass(string className)
        {
            ClassExpression classData = new ClassExpression(GeneratorFactory);
            if (_currentNamespace != null)
                _currentNamespace.AddGeneratableItem(classData.Generator);
            else
                OutputFile.Current.AddGeneratableItem(classData.Generator);

            if (!string.IsNullOrEmpty(className))
                classData.Generator.Name = className;
            return classData;
        }

        public void Namespace(string name)
        {
            _currentNamespace = new NamespaceExpression();
            _currentNamespace.Generator.Name = name;
            OutputFile.Current.AddGeneratableItem(_currentNamespace.Generator);
        }

        public void RunMyGenerationTemplate(Dictionary<string, object> data, string templateFileLocation, string outputPath)
        {
            _myGenerationService.RunMyGenerationTemplate(data, templateFileLocation, outputPath);
        }

        
    }
}
