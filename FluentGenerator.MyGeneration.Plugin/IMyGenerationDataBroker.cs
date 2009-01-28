using System.Collections.Generic;

namespace FluentGenerator.MyGeneration.Plugin
{
    public interface IMyGenerationDataBroker
    {
        Dictionary<string, object> GetData();
        void SaveData(Dictionary<string, object> data);
    }
}