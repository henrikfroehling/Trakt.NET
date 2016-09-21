namespace TraktApiSharp.Tests.Experimental.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Experimental.Responses;

    [TestClass]
    public class ITraktPaginationResponseHeadersTests
    {
        [TestMethod]
        public void TestITraktPaginationResponseHeadersIsInterface()
        {
            typeof(ITraktPaginationResponseHeaders).IsInterface.Should().BeTrue();
        }

        [TestMethod]
        public void TestITraktPaginationResponseHeadersHasPageProperty()
        {
            var userCountPropertyInfo = typeof(ITraktPaginationResponseHeaders).GetProperties()
                                                                               .Where(p => p.Name == "Page")
                                                                               .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [TestMethod]
        public void TestITraktPaginationResponseHeadersHasLimitProperty()
        {
            var userCountPropertyInfo = typeof(ITraktPaginationResponseHeaders).GetProperties()
                                                                               .Where(p => p.Name == "Limit")
                                                                               .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [TestMethod]
        public void TestITraktPaginationResponseHeadersHasPageCountProperty()
        {
            var userCountPropertyInfo = typeof(ITraktPaginationResponseHeaders).GetProperties()
                                                                               .Where(p => p.Name == "PageCount")
                                                                               .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [TestMethod]
        public void TestITraktPaginationResponseHeadersHasItemCountProperty()
        {
            var userCountPropertyInfo = typeof(ITraktPaginationResponseHeaders).GetProperties()
                                                                               .Where(p => p.Name == "ItemCount")
                                                                               .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }
    }
}
