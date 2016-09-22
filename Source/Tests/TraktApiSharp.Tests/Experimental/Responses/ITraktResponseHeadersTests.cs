namespace TraktApiSharp.Tests.Experimental.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Experimental.Responses;

    [TestClass]
    public class ITraktResponseHeadersTests
    {
        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktResponseHeadersIsInterface()
        {
            typeof(ITraktResponseHeaders).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktResponseHeadersHasUserCountProperty()
        {
            var userCountPropertyInfo = typeof(ITraktResponseHeaders).GetProperties()
                                                                     .Where(p => p.Name == "UserCount")
                                                                     .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktResponseHeadersHasSortByProperty()
        {
            var userCountPropertyInfo = typeof(ITraktResponseHeaders).GetProperties()
                                                                     .Where(p => p.Name == "SortBy")
                                                                     .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktResponseHeadersHasSortHowProperty()
        {
            var userCountPropertyInfo = typeof(ITraktResponseHeaders).GetProperties()
                                                                     .Where(p => p.Name == "SortHow")
                                                                     .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
