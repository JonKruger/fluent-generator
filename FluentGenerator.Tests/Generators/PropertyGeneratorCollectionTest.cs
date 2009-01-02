using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentGenerator.Generators;
using Rhino.Mocks;

namespace FluentGenerator.Tests.Generators
{
    [TestFixture]
    public class When_generating_a_collection_of_properties : Given_a_CodeWriter
    {
        private PropertyGeneratorCollection _properties;

        protected override void Before_each()
        {
            base.Before_each();

            PropertyGenerator property1 = new PropertyGenerator { Name = "property1", Type = "string" };
            PropertyGenerator property2 = new PropertyGenerator { Name = "property2", Type = "string" };

            _properties = new PropertyGeneratorCollection();
            _properties.Add(property1);
            _properties.Add(property2);
        }

        [Test]
        public void Should_generate_all_properties_in_the_collection()
        {
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("public string property1 { get; set; }");
            expected.AppendLine("public string property2 { get; set; }");

            _properties.Generate(_codeWriter);
            _codeWriter.ToString().ShouldBe(expected.ToString());
        }
    }
}
