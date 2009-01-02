using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Generators;
using NUnit.Framework;

namespace FluentGenerator.Tests
{
    public class When_generating_a_field : Given_a_CodeWriter
    {
        [Test]
        public void Should_generate_the_field()
        {
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("public string _field;");

            FieldGenerator field = new FieldGenerator() { Name = "_field", Type = "string" };
            field.Generate(_codeWriter);
            _codeWriter.ToString().ShouldBe(expected.ToString());
        }

        [Test]
        public void Should_format_the_name_as_camel_case_underscore()
        {
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("public string _field;");

            FieldGenerator field = new FieldGenerator() { Name = "Field", Type = "string" };
            field.Generate(_codeWriter);
            _codeWriter.ToString().ShouldBe(expected.ToString());
        }

        [Test]
        [ExpectedException(typeof(GenerationException))]
        public void Should_throw_exception_if_name_was_not_specified()
        {
            FieldGenerator field = new FieldGenerator { Type = "string" };
            field.Generate(_codeWriter);
        }

        [Test]
        [ExpectedException(typeof(GenerationException))]
        public void Should_throw_exception_if_type_was_not_specified()
        {
            FieldGenerator field = new FieldGenerator { Name = "_field" };
            field.Generate(_codeWriter);
        }
    }
}
