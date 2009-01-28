using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using StructureMap;

namespace FluentGenerator.MyGeneration.Plugin
{
    /// <summary>
    /// Class that is exposed to MyGeneration templates.
    /// </summary>
    public class Values
    {
        private Dictionary<string, object> _data;
        private IMyGenerationDataBroker _myGenerationDataBroker;

        public Values()
        {
            // MyGeneration says that we have to have a constructor
            // with no arguments... OK.

            try
            {
                ObjectFactory.Configure(x => x.AddRegistry<MyGenerationPluginRegistry>());

                _myGenerationDataBroker = ObjectFactory.GetInstance<IMyGenerationDataBroker>();
                LoadData();
            }
            catch (Exception ex)
            {
                throw new MyGenerationPluginException("Error in FluentGenerator plugin for MyGeneration.", ex);
            }
        }

        private void LoadData()
        {
            _data = _myGenerationDataBroker.GetData();
        }

        public object this[string key]
        {
            get
            {
                try
                {
                    return _data[key];
                }
                catch (Exception ex)
                {
                    throw new MyGenerationPluginException("Error in FluentGenerator plugin for MyGeneration.", ex);
                }
            }
        }

        public string Test()
        {
            return "It works!";
        }
    }
}
