using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using FluentGenerator.Service;

namespace FluentGenerator.Tests
{
    [TestFixture]
    public class When_creating_an_OutputFile : Specification
    {
        private IFileSystemService _fileSystemService;

        protected override void Before_each()
        {
            base.Before_each();
            _fileSystemService = Stub<IFileSystemService>();
            OutputFile.Current = null;
        }

        protected override void After_each()
        {
            base.After_each();
            OutputFile.Current = null;
        }

        [Test]
        public void Should_set_the_newly_created_OutputFile_as_the_current_one()
        {
            OutputFile file = new OutputFile("", _fileSystemService);
            OutputFile.Current.ShouldBe(file);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Should_throw_exception_if_another_OutputFile_is_created_before_the_first_one_is_disposed()
        {
            OutputFile file1 = new OutputFile("", _fileSystemService);
            OutputFile file2 = new OutputFile("", _fileSystemService);
        }
    }

    [TestFixture]
    public class When_disposing_an_OutputFile : Specification
    {
        private Generator _generator;
        private OutputFile _outputFile;

        protected override void Before_each()
        {
            base.Before_each();

            _generator = Partial<Generator>(Stub<IFileSystemService>(), Stub<ICodeWriter>());
            _generator.Stub(g => g.GenerateFile(null)).IgnoreArguments();

            ReplayAll();

            using (_outputFile = new OutputFile("", Stub<IFileSystemService>()))
            {

            }
        }

        protected override void After_each()
        {
            base.After_each();
            OutputFile.Current = null;
        }

        [Test]
        public void Should_generate_the_file()
        {
            _generator.AssertWasCalled(g => g.GenerateFile(_outputFile));
        }

        [Test]
        public void There_should_be_no_current_OutputFile()
        {
            OutputFile.Current.ShouldBeNull();
        }
    }
}
