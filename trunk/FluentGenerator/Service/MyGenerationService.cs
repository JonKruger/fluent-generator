using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FluentGenerator.MyGeneration.Plugin;

namespace FluentGenerator.Service
{
    public class MyGenerationService : IMyGenerationService
    {
        private string _myGenerationExePath;
        private bool? _alwaysCopyPluginFiles;
        private IFileSystemService _fileSystemService;
        private IMessageBoxService _messageBoxService;
        private IMyGenerationDataBroker _myGenerationDataBroker;

        public MyGenerationService(IFileSystemService fileSystemService, IMessageBoxService messageBoxService,
            IMyGenerationDataBroker myGenerationDataBroker)
        {
            _fileSystemService = fileSystemService;
            _messageBoxService = messageBoxService;
            _myGenerationDataBroker = myGenerationDataBroker;
        }

        public string MyGenerationExePath
        {
            get { return _myGenerationExePath ?? ConfigurationManager.AppSettings["MyGenerationExePath"]; }
            set { _myGenerationExePath = value; }
        }

        public bool AlwaysCopyPluginFiles
        {
            get
            {
                if (_alwaysCopyPluginFiles != null)
                    return _alwaysCopyPluginFiles.Value;

                bool value;
                if (bool.TryParse(ConfigurationManager.AppSettings["AlwaysCopyPluginFiles"], out value))
                    return value;
                return false;
            }
            set { _alwaysCopyPluginFiles = value; }
        }

        /// <summary>
        /// Run a MyGeneration template.
        /// </summary>
        /// <returns>The console output from MyGeneration.</returns>
        public string RunMyGenerationTemplate(Dictionary<string, object> data, string templateFileLocation, string outputPath)
        {
            CopyPluginToMyGenerationFolder(false);
            StoreDataForMyGenerationPlugin(data);

            // MyGeneration won't create the directory, so we have to do it.
            if (!_fileSystemService.DirectoryExists(Path.GetDirectoryName(outputPath)))
                _fileSystemService.CreateDiretory(Path.GetDirectoryName(outputPath));

            string logFilePath = Path.GetTempFileName();
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = MyGenerationExePath;
                p.StartInfo.Arguments =
                    string.Format("-r -t \"{0}\" -o \"{1}\" -l \"{2}\" -aio \"{3}\" FluentGenerator.MyGeneration.Plugin.Values Values",
                        templateFileLocation,
                        outputPath,
                        logFilePath,
                        Path.Combine(Path.GetDirectoryName(MyGenerationExePath), "FluentGenerator.MyGeneration.Plugin.dll"));
                p.StartInfo.CreateNoWindow = true;
                //p.StartInfo.WorkingDirectory = Path.GetDirectoryName(MyGenerationExePath);
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.Start();
                p.WaitForExit();

                string output = p.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
                return output;
                //return Utilities.ReadFile(logFilePath);
            }
            finally
            {
                try
                {
                    File.Delete(logFilePath);
                }
                catch
                {
                }
            }
        }

        public virtual string GetFolderToCopyPluginTo()
        {
            // copy the plugin to the same folder as MyGeneration .exe
            return Path.GetDirectoryName(MyGenerationExePath);
        }

        public virtual string GetFolderThatContainsPlugin()
        {
            return Path.GetDirectoryName(GetType().Assembly.Location);
        }

        public bool CopyPluginToMyGenerationFolder(bool forceReplaceOfExistingFile)
        {
            if (string.IsNullOrEmpty(MyGenerationExePath))
                throw new InvalidOperationException("MyGenerationExePath must be configured in the app.config file or by setting the property on this class.");

            string errorMessage = "";

            var pluginPath = Path.Combine(GetFolderToCopyPluginTo(), "FluentGenerator.MyGeneration.Plugin.dll");
            var structureMapPath = Path.Combine(GetFolderToCopyPluginTo(), "StructureMap.dll");
            if (forceReplaceOfExistingFile || AlwaysCopyPluginFiles ||
                !_fileSystemService.Exists(pluginPath) || !_fileSystemService.Exists(structureMapPath))
            {
                try
                {
                    _fileSystemService.Copy(
                        Path.Combine(GetFolderThatContainsPlugin(), "FluentGenerator.MyGeneration.Plugin.dll"),
                        pluginPath, true);
                    _fileSystemService.Copy(
                        Path.Combine(GetFolderThatContainsPlugin(), "StructureMap.dll"),
                        structureMapPath, true);
                }
                catch (IOException)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Error copying FluentGenerator.MyGeneration.Plugin.dll to the MyGeneration folder.");
                    sb.AppendLine("Please close MyGeneration or set \"AlwaysCopyPluginFiles\" to \"false\" in the app.config file.");
                    errorMessage += sb.ToString();
                }
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                _messageBoxService.Show(errorMessage, "Fluent Generator");
                return false;
            }

            return true;
        }

        private void StoreDataForMyGenerationPlugin(Dictionary<string, object> data)
        {
            _myGenerationDataBroker.SaveData(data);
        }
    }
}
