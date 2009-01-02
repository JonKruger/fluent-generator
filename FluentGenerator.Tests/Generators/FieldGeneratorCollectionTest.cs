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
    public class When_generating_a_collection_of_fields : Given_a_CodeWriter
    {
        private FieldGeneratorCollection _fields;

        protected override void Before_each()
        {
            base.Before_each();

            var field1 = Stub<IFieldGenerator>();
            var field2 = Stub<IFieldGenerator>();

            field1.Stub(m => m.Generate(_codeWriter))
                .WhenCalled(field => ((ICodeWriter)field.Arguments[0]).AppendLine("field1"));
            field2.Stub(m => m.Generate(_codeWriter))
                .WhenCalled(field => ((ICodeWriter)field.Arguments[0]).AppendLine("field2"));

            _fields = new FieldGeneratorCollection();
            _fields.Add(field1);
            _fields.Add(field2);
        }

        [Test]
        public void Should_generate_all_fields_in_the_collection()
        {
            _fields.Generate(_codeWriter);
            _codeWriter.ToString().ShouldBe("field1\r\nfield2\r\n");
        }
    }
}
