using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.MyGeneration.Plugin;
using FluentGenerator.Service;
using NUnit.Framework;
using Rhino.Mocks;
using System.IO;

namespace FluentGenerator.Tests.Service
{
    [TestFixture]
    public class When_copying_the_MyGeneration_plugin : Specification
    {
        private IFileSystemService _fileSystemService;
        private IMessageBoxService _messageBoxService;
        private MyGenerationService _myGenerationService;
        private IMyGenerationDataBroker _myGenerationDataBroker;

        protected override void Before_each()
        {
            base.Before_each();

            _fileSystemService = Stub<IFileSystemService>();
            _messageBoxService = Stub<IMessageBoxService>();
            _myGenerationDataBroker = Stub<IMyGenerationDataBroker>();

            _myGenerationService = Partial<MyGenerationService>(_fileSystemService, _messageBoxService, this._myGenerationDataBroker);
            _myGenerationService.Stub(mgs => mgs.GetFolderThatContainsPlugin()).Return(@"c:\from\");
            _myGenerationService.Stub(mgs => mgs.GetFolderToCopyPluginTo()).Return(@"c:\to\");
            _myGenerationService.MyGenerationExePath = @"c:\we\dont\care";
        }

        [Test]
        public void Should_copy_the_plugin_file_if_it_does_not_exist()
        {
            _fileSystemService.Stub(fss => fss.Exists(null)).IgnoreArguments().Return(false);
            _myGenerationService.AlwaysCopyPluginFiles = false;
            _myGenerationService.CopyPluginToMyGenerationFolder(false);
            _fileSystemService.AssertWasCalled(fss => fss.Copy(
                                                          @"c:\from\FluentGenerator.MyGeneration.Plugin.dll",
                                                          @"c:\to\FluentGenerator.MyGeneration.Plugin.dll",
                                                          true));
        }

        [Test]
        public void Should_copy_StructureMap_if_it_does_not_exist()
        {
            _fileSystemService.Stub(fss => fss.Exists(null)).IgnoreArguments().Return(false);
            _myGenerationService.AlwaysCopyPluginFiles = false;
            _myGenerationService.CopyPluginToMyGenerationFolder(false);
            _fileSystemService.AssertWasCalled(fss => fss.Copy(
                                                          @"c:\from\StructureMap.dll",
                                                          @"c:\to\StructureMap.dll",
                                                          true));
        }

        [Test]
        public void Should_copy_the_plugin_file_if_you_specified_to_always_copy_the_file()
        {
            _fileSystemService.Stub(fss => fss.Exists(null)).IgnoreArguments().Return(true);
            _myGenerationService.AlwaysCopyPluginFiles = true;
            _myGenerationService.CopyPluginToMyGenerationFolder(false);
            _fileSystemService.AssertWasCalled(fss => fss.Copy(
                                                          @"c:\from\FluentGenerator.MyGeneration.Plugin.dll",
                                                          @"c:\to\FluentGenerator.MyGeneration.Plugin.dll",
                                                          true));
        }

        [Test]
        public void Should_copy_StructureMap_if_you_specified_to_always_copy_the_file()
        {
            _fileSystemService.Stub(fss => fss.Exists(null)).IgnoreArguments().Return(true);
            _myGenerationService.AlwaysCopyPluginFiles = true;
            _myGenerationService.CopyPluginToMyGenerationFolder(false);
            _fileSystemService.AssertWasCalled(fss => fss.Copy(
                                                          @"c:\from\StructureMap.dll",
                                                          @"c:\to\StructureMap.dll",
                                                          true));
        }

        [Test]
        public void Should_copy_the_plugin_file_if_you_specified_to_force_replacement_of_the_existing_file()
        {
            _fileSystemService.Stub(fss => fss.Exists(null)).IgnoreArguments().Return(true);
            _myGenerationService.AlwaysCopyPluginFiles = false;
            _myGenerationService.CopyPluginToMyGenerationFolder(true);
            _fileSystemService.AssertWasCalled(fss => fss.Copy(
                                                          @"c:\from\FluentGenerator.MyGeneration.Plugin.dll",
                                                          @"c:\to\FluentGenerator.MyGeneration.Plugin.dll",
                                                          true));
        }

        [Test]
        public void Should_copy_StructureMap_if_you_specified_to_force_replacement_of_the_existing_file()
        {
            _fileSystemService.Stub(fss => fss.Exists(null)).IgnoreArguments().Return(true);
            _myGenerationService.AlwaysCopyPluginFiles = false;
            _myGenerationService.CopyPluginToMyGenerationFolder(true);
            _fileSystemService.AssertWasCalled(fss => fss.Copy(
                                                          @"c:\from\StructureMap.dll",
                                                          @"c:\to\StructureMap.dll",
                                                          true));
        }

        [Test]
        public void Should_not_copy_the_file_in_any_other_situation()
        {
            _fileSystemService.Stub(fss => fss.Exists(null)).IgnoreArguments().Return(true);
            _myGenerationService.AlwaysCopyPluginFiles = false;
            _myGenerationService.CopyPluginToMyGenerationFolder(false);
            _fileSystemService.AssertWasNotCalled(fss => fss.Copy(null, null, true), o => o.IgnoreArguments());
        }

        [Test]
        public void Should_show_a_message_box_if_an_exception_happens_while_copying_the_file()
        {
            _fileSystemService.Stub(fss => fss.Exists(null)).IgnoreArguments().Return(false);
            _myGenerationService.AlwaysCopyPluginFiles = false;
            _fileSystemService.Stub(fss => fss.Copy(null, null, true)).IgnoreArguments().Throw(new IOException());
            _myGenerationService.CopyPluginToMyGenerationFolder(false);
            _messageBoxService.AssertWasCalled(mbs => mbs.Show(null, null), o => o.IgnoreArguments());
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Should_throw_exception_if_MyGenerationExePath_is_not_set()
        {
            _myGenerationService.MyGenerationExePath = string.Empty;
            _myGenerationService.CopyPluginToMyGenerationFolder(false);
        }
    }
}
