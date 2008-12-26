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

            OpenNamespaceExpression nsData = new OpenNamespaceExpression(_generator).WithName("Sample.Namespace");
            nsData.Generate(_codeWriter);

            ClassExpression data = new ClassExpression(_generator).WithName("Sample");
            data.Generate(_codeWriter);

            CloseNamespaceExpression closeData = new CloseNamespaceExpression(_generator);
            closeData.Generate(_codeWriter);
            
            _codeWriter.ToString().ShouldBe(expected.ToString());
        }
    }
}
