namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ITraktPaginationTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationIsInterface()
        {
            typeof(ITraktPagination).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationHasPageProperty()
        {
            var paginationOptionsPropertyInfo = typeof(ITraktPagination).GetProperties()
                                                                        .Where(p => p.Name == "Page")
                                                                        .FirstOrDefault();

            paginationOptionsPropertyInfo.CanRead.Should().BeTrue();
            paginationOptionsPropertyInfo.CanWrite.Should().BeTrue();
            paginationOptionsPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationHasLimitProperty()
        {
            var paginationOptionsPropertyInfo = typeof(ITraktPagination).GetProperties()
                                                                        .Where(p => p.Name == "Limit")
                                                                        .FirstOrDefault();

            paginationOptionsPropertyInfo.CanRead.Should().BeTrue();
            paginationOptionsPropertyInfo.CanWrite.Should().BeTrue();
            paginationOptionsPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }
    }
}
