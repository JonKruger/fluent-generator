using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Extensions;
using NUnit.Framework;

namespace FluentGenerator.Tests
{
    [TestFixture]
    public class When_generating_classes_with_namespaces : Given_a_Generator
    {
        [Test]
        public void Should_write_out_the_namespace()
        {
            StringBuilder expected = new StringBuilder();
            expected.AppendLineFormat("namespace Sample.Namespace");
            expected.AppendLineFormat("{");
            expected.AppendLineFormat("    public class Sample");
            expected.AppendLineFormat("    {");
            expected.AppendLineFormat("    }");
            expected.AppendLineFormat("}");
            expected.AppendLine();

            NamespaceExpression nsData = new NamespaceExpression(_generator).WithName("Sample.Namespace");

            ClassExpression data = new ClassExpression(_generator).WithName("Sample");
            nsData.GeneratableItems.Add(data);

            nsData.Generate(_codeWriter);

            _codeWriter.ToString().ShouldBe(expected.ToString());
        }
    }
}
