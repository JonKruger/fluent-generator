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
            public FieldGeneratorCollection Fields { get; private set; }
            public PropertyGeneratorCollection Properties { get; private set; }
            public MethodGeneratorCollection Methods { get; private set; }

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
            _generatorFactory.CreateClassGenerator();
        }
    }
}
