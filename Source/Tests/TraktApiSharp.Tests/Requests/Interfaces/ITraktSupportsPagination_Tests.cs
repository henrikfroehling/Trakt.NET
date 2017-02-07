namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Requests.Interfaces;
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
            var propertyInfo = typeof(ITraktSupportsPagination).GetProperties()
                                                               .Where(p => p.Name == "Page")
                                                               .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktSupportsPagination_Has_Limit_Property()
        {
            var propertyInfo = typeof(ITraktSupportsPagination).GetProperties()
                                                               .Where(p => p.Name == "Limit")
                                                               .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }
    }
}
