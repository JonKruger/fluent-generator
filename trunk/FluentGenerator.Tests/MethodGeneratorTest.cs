using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentGenerator.Generators;

namespace FluentGenerator.Tests
{
    [TestFixture]
    public class When_generating_methods : Specification
    {
        private ICodeWriter _codeWriter;

        protected override void Before_each()
        {
            base.Before_each();

            _codeWriter = new CodeWriter();
        }

        [Test]
        public void Should_generate_the_method()
        {
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("public string Method()");
            expected.AppendLine("{");
            expected.AppendLine("}");

            MethodGenerator mg = new MethodGenerator();
            mg.Name = "Method";
            mg.ReturnType = "string";
            mg.Generate(_codeWriter);

            _codeWriter.ToString().ShouldBe(expected.ToString());
        }

        [Test]
        [ExpectedException(typeof(GenerationException))]
        public void Should_throw_exception_if_name_is_not_specified()
        {
            MethodGenerator mg = new MethodGenerator();
            mg.ReturnType = "string";
            mg.Generate(_codeWriter);   
        }

        [Test]
        [ExpectedException(typeof(GenerationException))]
        public void Should_throw_exception_if_return_type_is_not_specified()
        {
            MethodGenerator mg = new MethodGenerator();
            mg.Name = "Method";
            mg.Generate(_codeWriter);
        }
    }
}
