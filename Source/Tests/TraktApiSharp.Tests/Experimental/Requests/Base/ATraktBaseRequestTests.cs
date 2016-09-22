namespace TraktApiSharp.Tests.Experimental.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktBaseRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Abstract Base Classes")]
        public void TestATraktBaseRequestIsAbstract()
        {
            typeof(ATraktBaseRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Abstract Base Classes")]
        public void TestATraktBaseRequestImplementsITraktUriBuildableInterface()
        {
            typeof(ATraktBaseRequest).GetInterfaces().Should().Contain(typeof(ITraktUriBuildable));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Abstract Base Classes")]
        public void TestATraktBaseRequestHasClientProperty()
        {
            var clientPropertyInfo = typeof(ATraktBaseRequest)
                .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.Name == "Client")
                .FirstOrDefault();

            clientPropertyInfo.CanRead.Should().BeTrue();
            clientPropertyInfo.CanWrite.Should().BeFalse();
            clientPropertyInfo.PropertyType.Should().Be(typeof(TraktClient));
        }
    }
}
