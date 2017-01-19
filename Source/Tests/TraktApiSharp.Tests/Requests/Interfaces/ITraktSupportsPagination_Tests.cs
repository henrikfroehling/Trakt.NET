namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Interfaces")]
    public class ITraktSupportsPagination_Tests
    {
        [Fact]
        public void Test_ITraktSupportsPagination_Is_Interface()
        {
            typeof(ITraktSupportsPagination).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSupportsPagination_Has_Page_Property()
        {
            var paginationOptionsPropertyInfo = typeof(ITraktSupportsPagination).GetProperties()
                                                                                .Where(p => p.Name == "Page")
                                                                                .FirstOrDefault();

            paginationOptionsPropertyInfo.CanRead.Should().BeTrue();
            paginationOptionsPropertyInfo.CanWrite.Should().BeTrue();
            paginationOptionsPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktSupportsPagination_Has_Limit_Property()
        {
            var paginationOptionsPropertyInfo = typeof(ITraktSupportsPagination).GetProperties()
                                                                                .Where(p => p.Name == "Limit")
                                                                                .FirstOrDefault();

            paginationOptionsPropertyInfo.CanRead.Should().BeTrue();
            paginationOptionsPropertyInfo.CanWrite.Should().BeTrue();
            paginationOptionsPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }
    }
}
