using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Extensions;

namespace FluentGenerator
{
    public class ClassExpression : IClassExpression
    {
        private string _className;
        private bool _withPropertyChanging;
        private bool _withPropertyChanged;
        private string _primaryKeyProperty;
        private FieldExpressionCollection _fields = new FieldExpressionCollection();
        private PropertyExpressionCollection _properties = new PropertyExpressionCollection();
        private MethodExpressionCollection _methods = new MethodExpressionCollection();
        private string _databaseTableName;
        private readonly IGenerator _generator;

        public IGenerator Generator
        {
            get { return _generator; }
        }

        public ClassExpression(IGenerator generator)
        {
            _generator = generator;
        }

        public virtual void Generate(ICodeWriter codeWriter)
        {
            codeWriter.AppendLineFormat("public class {0}", _className);
            codeWriter.AppendLineFormat("{");
            codeWriter.IncreaseIndent();
            _fields.Generate(codeWriter);
            _properties.Generate(codeWriter);
            _methods.Generate(codeWriter);
            codeWriter.DecreaseIndent();
            codeWriter.AppendLineFormat("}");
        }

        public ClassExpression WithName(string className)
        {
            _className = className;
            return this;
        }

        public ClassExpression WithPropertyChanging()
        {
            _withPropertyChanging = true;
            return this;
        }

        public ClassExpression WithPropertyChanged()
        {
            _withPropertyChanged = true;
            return this;
        }

        public ClassExpression AddPrimaryKeyProperty(string propertyName)
        {
            AddProperty(propertyName).OfType("int");
            return this;
        }

        public PropertyExpression AddProperty(string name)
        {
            PropertyExpression propertyExpression = new PropertyExpression(this);
            _properties.Add(propertyExpression.WithName(name));
            return propertyExpression;            
        }

        public ClassExpression AddProperty(IPropertyExpression propertyExpression)
        {
            _properties.Add(propertyExpression);
            return this;
        }

        public ClassExpression AddProperties(IList<IPropertyExpression> propertyExpressions)
        {
            foreach (var property in propertyExpressions)
                _properties.Add(property);
            return this;
        }

        public ListExpression AddListOf(string listType)
        {
            ListExpression listExpression = new ListExpression(this);
            _properties.Add(listExpression.Of(listType));
            return listExpression;
        }

        public ClassExpression FromDatabaseTable(string databaseTableName)
        {
            _databaseTableName = databaseTableName;
            return this;
        }
    }
}
