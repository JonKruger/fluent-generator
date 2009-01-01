using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator.Generators
{
    public class ClassGenerator : IClassGenerator
    {
        private FieldGeneratorCollection _fields = new FieldGeneratorCollection();
        private PropertyGeneratorCollection _properties = new PropertyGeneratorCollection();
        private MethodGeneratorCollection _methods = new MethodGeneratorCollection();

        public string Name { get; set; }
        
        public FieldGeneratorCollection Fields
        {
            get { return _fields; }
        }

        public PropertyGeneratorCollection Properties
        {
            get { return _properties; }
        }

        public MethodGeneratorCollection Methods
        {
            get { return _methods; }
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
