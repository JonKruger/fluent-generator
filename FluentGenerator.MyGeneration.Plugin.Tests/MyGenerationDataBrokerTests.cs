using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FluentGenerator.Tests;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentGenerator.MyGeneration.Plugin.Tests
{
    [TestFixture]
    public class When_using_the_DataBroker : Specification
    {
        private MyGenerationDataBroker _myGenerationDataBroker;
        private string _tempFileName;

        protected override void Before_each()
        {
            base.Before_each();

            _tempFileName = Path.GetTempFileName();
            _myGenerationDataBroker = Partial<MyGenerationDataBroker>();
            _myGenerationDataBroker.DataPath = _tempFileName;
        }
        protected override void After_each()
        {
            base.After_each();

            try
            {
                if (File.Exists(_tempFileName))
                    File.Delete(_tempFileName);
            }
            catch (Exception)
            {

            }
        }

        [Test]
        public void GetData_should_return_the_values_passed_in_SaveData()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["1"] = 1;
            data["list"] = new List<string> { "a", "b", "c" };
            _myGenerationDataBroker.SaveData(data);

            var loadedData = _myGenerationDataBroker.GetData();
            loadedData.Keys.Count.ShouldBe(2);
            loadedData["1"].ShouldBe(1);
            ((List<string>)loadedData["list"]).ShouldBeAnIdenticalListTo((List<string>)data["list"]);
        }
    }
}
