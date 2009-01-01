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
        private GeneratorBase _generator;
        private OutputFile _outputFile;

        protected override void Before_each()
        {
            base.Before_each();

            _generator = Partial<GeneratorBase>(Stub<IGeneratorFactory>(), Stub<IFileSystemService>());
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

    [TestFixture]
    public class When_generating_an_OutputFile : Specification
    {
        private IFileSystemService _fileSystemService;
        private GeneratorBase _generator;

        protected override void Before_each()
        {
            base.Before_each();
            _fileSystemService = Stub<IFileSystemService>();
            _generator = Partial<GeneratorBase>(Stub<IGeneratorFactory>(), _fileSystemService);
        }

        [Test]
        public void Should_put_two_classes_inside_the_same_namespace_declaration_if_they_share_a_namespace()
        {
            //StringBuilder expected

            //using (new OutputFile("asdf", _fileSystemService))
            //{
            //    OutputFile.Current.SetNamespace("test");

            //    OutputFile.Current.AddGeneratableItem(new ClassExpression(_generator).WithName("class1"));
            //    OutputFile.Current.AddGeneratableItem(new ClassExpression(_generator).WithName("class2"));
            //}

            //_fileSystemService.AssertWasCalled(fss => fss.WriteToFile("asdf", data));
        }

        [Test]
        public void Should_put_two_classes_inside_separate_namespace_declarations_if_they_do_not_share_a_namespace()
        {
            
        }

        [Test]
        public void Should_group_classes_based_on_when_the_namespace_is_set()
        {
            
        }
    }
}
