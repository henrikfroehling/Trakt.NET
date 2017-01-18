namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Requests.Params;

    [TestClass]
    public class ITraktFilterableTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktFilterableIsInterface()
        {
            typeof(ITraktFilterable).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktFilterableHasFilterProperty()
        {
            var filterPropertyInfo = typeof(ITraktFilterable).GetProperties()
                                                             .Where(p => p.Name == "Filter")
                                                             .FirstOrDefault();

            filterPropertyInfo.CanRead.Should().BeTrue();
            filterPropertyInfo.CanWrite.Should().BeTrue();
            filterPropertyInfo.PropertyType.Should().Be(typeof(TraktCommonFilter));
        }
    }
}
