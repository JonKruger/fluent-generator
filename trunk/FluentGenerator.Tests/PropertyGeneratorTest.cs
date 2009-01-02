using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentGenerator.Generators;

namespace FluentGenerator.Tests
{
    [TestFixture]
    public class When_generating_a_property : Given_a_CodeWriter
    {
        [Test]
        public void Should_generate_the_property()
        {
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("public string Property { get; set; }");
            
            PropertyGenerator property = new PropertyGenerator { Name = "Property", Type = "string" };
            property.Generate(_codeWriter);
            _codeWriter.ToString().ShouldBe(expected.ToString());
        }

        [Test]
        [ExpectedException(typeof(GenerationException))]
        public void Should_throw_exception_if_name_was_not_specified()
        {
            PropertyGenerator property = new PropertyGenerator { Type = "string" };
            property.Generate(_codeWriter);
        }

        [Test]
        [ExpectedException(typeof(GenerationException))]
        public void Should_throw_exception_if_type_was_not_specified()
        {
            PropertyGenerator property = new PropertyGenerator { Name = "Property" };
            property.Generate(_codeWriter);
        }
    }
}
