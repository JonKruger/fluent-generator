using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Extensions;
using FluentGenerator.Generators;
using NUnit.Framework;

namespace FluentGenerator.Tests
{
    [TestFixture]
    public class When_generating_classes_with_namespaces : Given_a_CodeWriter
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

            NamespaceGenerator ns = new NamespaceGenerator {Name = "Sample.Namespace"};
            ClassGenerator c = new ClassGenerator {Name = "Sample"};
            ns.GeneratableItems.Add(c);
            ns.Generate(_codeWriter);

            _codeWriter.ToString().ShouldBe(expected.ToString());
        }
    }
}
