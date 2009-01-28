using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Generators;
using FluentGenerator.Tests;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentGenerator.Expressions.Tests
{
    [TestFixture]
    public class When_using_a_ClassExpression : Specification
    {
        private IGeneratorFactory _generatorFactory;

        protected override void Before_each()
        {
            base.Before_each();

            _generatorFactory = new GeneratorFactory();
        }

        [Test]
        public void Create_class_with_name()
        {
            ClassExpression expr = new ClassExpression(_generatorFactory);
            expr.WithName("Something");
            expr.Generator.Name.ShouldBe("Something");
        }

        [Test]
        public void Create_class_with_property()
        {
            ClassExpression expr = new ClassExpression(_generatorFactory);
            expr.WithName("Something").AddProperty("Property").OfType("string");
            expr.Generator.Name.ShouldBe("Something");
            expr.Generator.Properties.Count.ShouldBe(1);
            expr.Generator.Properties[0].Name.ShouldBe("Property");
            expr.Generator.Properties[0].Type.ShouldBe("string");
        }
    }
}
