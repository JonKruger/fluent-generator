using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator.Generators
{
    public class ClassGenerator : IClassGenerator
    {
        private IFieldGeneratorCollection _fields;
        private IPropertyGeneratorCollection _properties;
        private IMethodGeneratorCollection _methods;
        private IGeneratorFactory _generatorFactory;

        public string Name { get; set; }
        
        public IFieldGeneratorCollection Fields
        {
            get { return _fields; }
        }

        public IPropertyGeneratorCollection Properties
        {
            get { return _properties; }
        }

        public IMethodGeneratorCollection Methods
        {
            get { return _methods; }
        }

        public ClassGenerator(IGeneratorFactory generatorFactory)
        {
            _generatorFactory = generatorFactory;
            _fields = _generatorFactory.CreateFieldGeneratorCollection();
            _properties = _generatorFactory.CreatePropertyGeneratorCollection();
            _methods = _generatorFactory.CreateMethodGeneratorCollection();
        }

        public virtual void Generate(ICodeWriter codeWriter)
        {
            codeWriter.AppendLineFormat("public class {0}", Name);
            codeWriter.AppendLineFormat("{");
            codeWriter.IncreaseIndent();
            Fields.Generate(codeWriter);

            if (Fields.Count > 0 && (Properties.Count > 0 || Methods.Count > 0))
                codeWriter.AppendLine();
            
            Properties.Generate(codeWriter);
            
            if (Properties.Count > 0 && Methods.Count > 0)
                codeWriter.AppendLine();
            
            Methods.Generate(codeWriter);
            codeWriter.DecreaseIndent();
            codeWriter.AppendLineFormat("}");
        }
    }
}
