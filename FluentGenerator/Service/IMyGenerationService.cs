using System.Collections.Generic;

namespace FluentGenerator.Service
{
    public interface IMyGenerationService
    {
        string MyGenerationExePath { get; set; }
        bool AlwaysCopyPluginFiles { get; set; }

        /// <summary>
        /// Run a MyGeneration template.
        /// </summary>
        /// <returns>The console output from MyGeneration.</returns>
        string RunMyGenerationTemplate(Dictionary<string, object> data, string templateFileLocation, string outputPath);
    }
}