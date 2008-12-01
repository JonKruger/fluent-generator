using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Service;
using NUnit.Framework;
using Rhino.Mocks;

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

            _generatable1.Stub(g => g.Generate()).Return("value1");
            _generatable2.Stub(g => g.Generate()).Return("value2");

            _outputFile = new OutputFile(@"c:\path.txt");
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
            _generatable1.AssertWasCalled(g => g.Generate());
            _generatable2.AssertWasCalled(g => g.Generate());
        }
        
        [Test]
        public void Should_write_the_result_out_to_a_file()
        {
            _fileSystemService.AssertWasCalled(fss => fss.WriteToFile(@"c:\path.txt", "value1"));
            _fileSystemService.AssertWasCalled(fss => fss.WriteToFile(@"c:\path.txt", "value2"));
        }
    }
}
