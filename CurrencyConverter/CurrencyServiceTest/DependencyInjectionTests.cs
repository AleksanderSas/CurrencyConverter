using CurrencyService;
using CurrencyService.DependencyInjection;
using NUnit.Framework;
using System;
using Unity;

namespace CurrencyServiceTest
{
    /// <summary>
    /// This test class verify if DI engin is able to resolve dependencies
    /// e.g. there is no dependency loop
    /// </summary>
    class DependencyInjectionTests
    {
        private IUnityContainer _container;

        [SetUp]
        public void Serup()
        {
            _container = new UnityContainer();
            _container.LoadModule();
        }

        [TestCase(typeof(CurrencyConverter))]
        public void ResolverTests(Type type)
        {
            Assert.IsTrue(_container.Resolve(type) != null);
        }
    }
}
