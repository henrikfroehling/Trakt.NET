namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Requests;

    [TestClass]
    public class ITraktPaginationTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationIsInterface()
        {
            typeof(ITraktPagination).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationHasPaginationOptionsProperty()
        {
            var paginationOptionsPropertyInfo = typeof(ITraktPagination).GetProperties()
                                                                        .Where(p => p.Name == "PaginationOptions")
                                                                        .FirstOrDefault();

            paginationOptionsPropertyInfo.CanRead.Should().BeTrue();
            paginationOptionsPropertyInfo.CanWrite.Should().BeTrue();
            paginationOptionsPropertyInfo.PropertyType.Should().Be(typeof(TraktPaginationOptions));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationHasSupportsOnlyPaginationParametersProperty()
        {
            var supportsOnlyPaginationParametersPropertyInfo = typeof(ITraktPagination).GetProperties()
                                                                                       .Where(p => p.Name == "SupportsOnlyPaginationParameters")
                                                                                       .FirstOrDefault();

            supportsOnlyPaginationParametersPropertyInfo.CanRead.Should().BeTrue();
            supportsOnlyPaginationParametersPropertyInfo.CanWrite.Should().BeFalse();
            supportsOnlyPaginationParametersPropertyInfo.PropertyType.Should().Be(typeof(bool));
        }
    }
}
