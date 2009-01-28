using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FluentGenerator.MyGeneration.Plugin
{
    /// <summary>
    /// Responsible for getting data from the fluent generator and loading
    /// it up for MyGeneration.
    /// </summary>
    public class MyGenerationDataBroker : IMyGenerationDataBroker
    {
        private string _dataPath;
        public string DataPath
        {
            get { return (!string.IsNullOrEmpty(_dataPath) ? _dataPath : Path.Combine(Path.GetTempPath(), "MyGenerationDataBroker.tmp")); }
            set { _dataPath = value; }
        }

        public Dictionary<string, object> GetData()
        {
            using (Stream stream = CreateReadStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (Dictionary<string,object>)formatter.Deserialize(stream);
            }
        }

        public void SaveData(Dictionary<string, object> data)
        {
            using (Stream stream = CreateWriteStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, data);
            }
        }

        public virtual Stream CreateReadStream()
        {
            return new FileStream(DataPath, FileMode.Open, FileAccess.Read);
        }

        public virtual Stream CreateWriteStream()
        {
            return new FileStream(DataPath, FileMode.Create, FileAccess.Write);
        }
    }
}
