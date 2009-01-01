using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Extensions;
using FluentGenerator.Generators;

namespace FluentGenerator.Expressions
{
    public class ClassExpression : IClassExpression
    {
        private IClassGenerator _generator = new ClassGenerator();

        public IClassGenerator Generator
        {
            get { return _generator; }
        }

        public ClassExpression WithName(string className)
        {
            _generator.Name = className;
            return this;
        }

        //public ClassExpression WithPropertyChanging()
        //{
        //    _withPropertyChanging = true;
        //    return this;
        //}

        //public ClassExpression WithPropertyChanged()
        //{
        //    _withPropertyChanged = true;
        //    return this;
        //}

        public ClassExpression AddPrimaryKeyProperty(string propertyName)
        {
            AddProperty(propertyName).OfType("int");
            return this;
        }

        public PropertyExpression AddProperty(string name)
        {
            PropertyExpression propertyExpression = new PropertyExpression().WithName(name);
            _generator.Properties.Add(propertyExpression.Generator);
            return propertyExpression;            
        }

        public ClassExpression AddProperty(IPropertyExpression propertyExpression)
        {
            _generator.Properties.Add(propertyExpression.Generator);
            return this;
        }

        public ClassExpression AddProperties(IList<IPropertyExpression> propertyExpressions)
        {
            foreach (var property in propertyExpressions)
                _generator.Properties.Add(property.Generator);
            return this;
        }

        public ListExpression AddListOf(string listType)
        {
            ListExpression listExpression = new ListExpression();
            _generator.Properties.Add(listExpression.Of(listType).Generator);
            return listExpression;
        }

        //public ClassExpression FromDatabaseTable(string databaseTableName)
        //{
        //    _databaseTableName = databaseTableName;
        //    return this;
        //}
    }
}
