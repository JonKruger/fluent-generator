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
    public class When_generating_a_collection_of_methods : Given_a_CodeWriter
    {
        private MethodGeneratorCollection _methods;

        protected override void Before_each()
        {
            base.Before_each();

            var method1 = Stub<IMethodGenerator>();
            var method2 = Stub<IMethodGenerator>();

            method1.Stub(m => m.Generate(_codeWriter))
                .WhenCalled(method => ((ICodeWriter) method.Arguments[0]).AppendLine("method1"));
            method2.Stub(m => m.Generate(_codeWriter))
                .WhenCalled(method => ((ICodeWriter) method.Arguments[0]).AppendLine("method2"));

            _methods = new MethodGeneratorCollection();
            _methods.Add(method1);
            _methods.Add(method2);
        }

        [Test]
        public void Should_generate_all_methods_in_the_collection()
        {
            _methods.Generate(_codeWriter);
            _codeWriter.ToString().ShouldBe("method1\r\nmethod2\r\n");
        }
    }
}
