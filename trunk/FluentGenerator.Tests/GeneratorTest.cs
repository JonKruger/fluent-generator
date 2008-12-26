using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Extensions;
using FluentGenerator.Service;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace FluentGenerator.Tests
{
    [TestFixture]
    public class When_generating_a_file : Specification
    {
        private IGeneratable _generatable1;
        private IGeneratable _generatable2;
        private Generator _generator;
        private IFileSystemService _fileSystemService;
        private OutputFile _outputFile;

        protected override void Before_each()
        {
            base.Before_each();

            _generatable1 = Mock<IGeneratable>();
            _generatable2 = Mock<IGeneratable>();
            _fileSystemService = Mock<IFileSystemService>();

            _generatable1.Stub(g => g.Generate(null)).IgnoreArguments().WhenCalled(method => ((ICodeWriter)method.Arguments[0]).AppendLine("value1"));
            _generatable2.Stub(g => g.Generate(null)).IgnoreArguments().WhenCalled(method => ((ICodeWriter)method.Arguments[0]).AppendLine("value2"));

            _outputFile = new OutputFile(@"c:\path.txt", _fileSystemService);
            _outputFile.AddGeneratableItem(_generatable1);
            _outputFile.AddGeneratableItem(_generatable2);

            _generator = Partial<Generator>(_fileSystemService);
            ReplayAll();

            _generator.GenerateFile(_outputFile);
        }

        protected override void After_each()
        {
            base.After_each();

            OutputFile.Current = null;
        }

        [Test]
        public void Should_generate_each_item_in_the_OutputFile()
        {
            _generatable1.AssertWasCalled(g => g.Generate(null), o => o.IgnoreArguments());
            _generatable2.AssertWasCalled(g => g.Generate(null), o => o.IgnoreArguments());
        }

        [Test]
        public void Should_write_the_result_out_to_a_file()
        {
            _fileSystemService.AssertWasCalled(fss => fss.WriteToFile(@"c:\path.txt", "value1\r\nvalue2\r\n"));
        }
    }

    [TestFixture]
    public class When_generating_code : Specification
    {
        private Generator _generator;
        private IFileSystemService _fileSystemService;

        protected override void Before_each()
        {
            base.Before_each();

            _fileSystemService = Mock<IFileSystemService>();
            _generator = Partial<Generator>(_fileSystemService);
            _generator.Stub(g => g.GenerateFile(null)).IgnoreArguments().CallOriginalMethod(OriginalCallOptions.NoExpectation);
        }

        [Test]
        public void Should_wrap_classes_with_a_namespace()
        {
            StringBuilder expected = new StringBuilder();
            expected.AppendLineFormat("namespace Sample.Namespace");
            expected.AppendLineFormat("{");
            expected.AppendLineFormat("    public class Sample");
            expected.AppendLineFormat("    {");
            expected.AppendLineFormat("    }");
            expected.AppendLineFormat("}");
            expected.AppendLine();

            using (new OutputFile(@"c:\foo", _fileSystemService))
            {
                _generator.Namespace("Sample.Namespace");
                _generator.CreateClass().WithName("Sample");
            }

            _fileSystemService.AssertWasCalled(fss => fss.WriteToFile(@"c:\foo", expected.ToString()));
        }
    }
}