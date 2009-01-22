using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentGenerator.Generators;

namespace FluentGenerator.Tests
{
    public class Given_a_GeneratorFactory : Specification
    {
        protected GeneratorFactory _generatorFactory;

        protected override void Before_each()
        {
            base.Before_each();

            _generatorFactory = new GeneratorFactory();
        }
    }

    [TestFixture]
    public class When_creating_a_class_generator : Given_a_GeneratorFactory
    {
        public class TestClassGenerator : IClassGenerator
        {
            #region Implementation of IGeneratable

            public void Generate(ICodeWriter codeWriter)
            {
                throw new System.NotImplementedException();
            }

            #endregion

            #region Implementation of IClassGenerator

            public string Name { get; set; }
            public IFieldGeneratorCollection Fields { get; private set; }
            public IPropertyGeneratorCollection Properties { get; private set; }
            public IMethodGeneratorCollection Methods { get; private set; }

            #endregion
        }

        [Test]
        public void Should_create_an_instance_of_the_specified_class_generator()
        {
            _generatorFactory.ClassGeneratorTypeIs<TestClassGenerator>();
            _generatorFactory.CreateClassGenerator().ShouldBeOfType<TestClassGenerator>();
        }

        [Test]
        [ExpectedException(typeof(GenerationException))]
        public void Should_throw_exception_if_no_class_generator_was_specified()
        {
            _generatorFactory.Reset();
            _generatorFactory.CreateClassGenerator();
        }
    }

    [TestFixture]
    public class When_creating_a_namespace_generator : Given_a_GeneratorFactory
    {
        public class TestNamespaceGenerator : INamespaceGenerator
        {
            #region Implementation of IGeneratable

            public void Generate(ICodeWriter codeWriter)
            {
                throw new System.NotImplementedException();
            }

            #endregion

            #region Implementation of INamespaceGenerator

            public string Name { get; set; }
            public IList<IGeneratable> GeneratableItems
            {
                get { throw new System.NotImplementedException(); }
            }

            public FieldGeneratorCollection Fields { get; private set; }
            public PropertyGeneratorCollection Properties { get; private set; }
            public MethodGeneratorCollection Methods { get; private set; }

            #endregion
        }

        [Test]
        public void Should_create_an_instance_of_the_specified_namespace_generator()
        {
            _generatorFactory.NamespaceGeneratorTypeIs<TestNamespaceGenerator>();
            _generatorFactory.CreateNamespaceGenerator().ShouldBeOfType<TestNamespaceGenerator>();
        }

        [Test]
        [ExpectedException(typeof(GenerationException))]
        public void Should_throw_exception_if_no_namespace_generator_was_specified()
        {
            _generatorFactory.Reset();
            _generatorFactory.CreateNamespaceGenerator();
        }
    }

    [TestFixture]
    public class When_creating_a_property_generator : Given_a_GeneratorFactory
    {
        public class TestPropertyGenerator : IPropertyGenerator
        {
            #region Implementation of IGeneratable

            public void Generate(ICodeWriter codeWriter)
            {
                throw new System.NotImplementedException();
            }

            #endregion

            #region Implementation of IPropertyGenerator

            public string Type
            {
                get { throw new System.NotImplementedException(); }
                set { throw new System.NotImplementedException(); }
            }

            public string Name { get; set; }
            public IFieldGenerator ExtractBackingFieldExpression()
            {
                throw new System.NotImplementedException();
            }

            public void GeneratePropertyOnly(ICodeWriter codeWriter)
            {
                throw new System.NotImplementedException();
            }

            public FieldGeneratorCollection Fields { get; private set; }
            public PropertyGeneratorCollection Properties { get; private set; }
            public MethodGeneratorCollection Methods { get; private set; }

            #endregion
        }

        [Test]
        public void Should_create_an_instance_of_the_specified_property_generator()
        {
            _generatorFactory.PropertyGeneratorTypeIs<TestPropertyGenerator>();
            _generatorFactory.CreatePropertyGenerator().ShouldBeOfType<TestPropertyGenerator>();
        }

        [Test]
        [ExpectedException(typeof(GenerationException))]
        public void Should_throw_exception_if_no_property_generator_was_specified()
        {
            _generatorFactory.Reset();
            _generatorFactory.CreatePropertyGenerator();
        }
    }

    [TestFixture]
    public class When_creating_a_field_generator : Given_a_GeneratorFactory
    {
        public class TestFieldGenerator : IFieldGenerator
        {
            #region Implementation of IGeneratable

            public void Generate(ICodeWriter codeWriter)
            {
                throw new System.NotImplementedException();
            }

            #endregion

            #region Implementation of IFieldGenerator

            public string Name { get; set; }
            public string Type
            {
                get { throw new System.NotImplementedException(); }
                set { throw new System.NotImplementedException(); }
            }

            public FieldGeneratorCollection Fields { get; private set; }
            public PropertyGeneratorCollection Properties { get; private set; }
            public MethodGeneratorCollection Methods { get; private set; }

            #endregion
        }

        [Test]
        public void Should_create_an_instance_of_the_specified_field_generator()
        {
            _generatorFactory.FieldGeneratorTypeIs<TestFieldGenerator>();
            _generatorFactory.CreateFieldGenerator().ShouldBeOfType<TestFieldGenerator>();
        }

        [Test]
        [ExpectedException(typeof(GenerationException))]
        public void Should_throw_exception_if_no_field_generator_was_specified()
        {
            _generatorFactory.Reset();
            _generatorFactory.CreateFieldGenerator();
        }
    }

    [TestFixture]
    public class When_creating_a_method_generator : Given_a_GeneratorFactory
    {
        public class TestMethodGenerator : IMethodGenerator
        {
            #region Implementation of IGeneratable

            public void Generate(ICodeWriter codeWriter)
            {
                throw new System.NotImplementedException();
            }

            #endregion

            #region Implementation of IMethodGenerator

            public string Name { get; set; }

            #endregion
        }

        [Test]
        public void Should_create_an_instance_of_the_specified_method_generator()
        {
            _generatorFactory.MethodGeneratorTypeIs<TestMethodGenerator>();
            _generatorFactory.CreateMethodGenerator().ShouldBeOfType<TestMethodGenerator>();
        }

        [Test]
        [ExpectedException(typeof(GenerationException))]
        public void Should_throw_exception_if_no_method_generator_was_specified()
        {
            _generatorFactory.Reset();
            _generatorFactory.CreateMethodGenerator();
        }
    }
}
