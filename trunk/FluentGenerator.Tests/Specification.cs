using System;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Impl;
using Rhino.Mocks.Interfaces;

namespace FluentGenerator.Tests
{
    [TestFixture]
    public class Specification
    {
        [SetUp]
        public void Initialize()
        {
            Mocks = new MockRepository();
            Before_each();
        }

        [TearDown]
        public void Cleanup()
        {
            After_each();
        }

        protected virtual void Before_each() { }
        protected virtual void After_each() { }

        public MockRepository Mocks { get; private set; }

        protected T Mock<T>() where T : class 
        {
            return MockRepository.GenerateMock<T>();
        }

        protected T Stub<T>() where T : class 
        {
            return MockRepository.GenerateStub<T>();
        }

        protected T Stub<T>(params object[] args) where T : class 
        {
            return MockRepository.GenerateStub<T>(args);
        }

        protected T Partial<T>() where T : class
        {
            return Mocks.PartialMock<T>();
        }

        protected T Partial<T>(params object[] args) where T : class
        {
            return Mocks.PartialMock<T>(args);
        }

        protected void Raise(object mock, string eventName, object sender, EventArgs args)
        {
            new EventRaiser((IMockedObject)mock, eventName).Raise(sender, args);
        }

        protected void ReplayAll()
        {
            Mocks.ReplayAll();
        }
    }
}
