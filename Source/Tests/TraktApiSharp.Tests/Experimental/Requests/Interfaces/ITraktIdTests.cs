namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ITraktIdTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktIdIsInterface()
        {
            typeof(ITraktId).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktIdDerivesFromITraktValidatableInterface()
        {
            typeof(ITraktId).GetInterfaces().Should().Contain(typeof(ITraktValidatable));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktIdDerivesFromITraktPathParametersInterface()
        {
            typeof(ITraktId).GetInterfaces().Should().Contain(typeof(ITraktPathParameters));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktIdHasIdProperty()
        {
            var idPropertyInfo = typeof(ITraktId).GetProperties()
                                                 .Where(p => p.Name == "Id")
                                                 .FirstOrDefault();

            idPropertyInfo.CanRead.Should().BeTrue();
            idPropertyInfo.CanWrite.Should().BeTrue();
            idPropertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
