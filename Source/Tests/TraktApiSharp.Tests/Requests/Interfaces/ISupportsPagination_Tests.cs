namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Interfaces")]
    public class ISupportsPagination_Tests
    {
        [Fact]
        public void Test_ISupportsPagination_Is_Interface()
        {
            typeof(ISupportsPagination).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ISupportsPagination_Has_Page_Property()
        {
            var propertyInfo = typeof(ISupportsPagination).GetProperties()
                                                               .Where(p => p.Name == "Page")
                                                               .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [Fact]
        public void Test_ISupportsPagination_Has_Limit_Property()
        {
            var propertyInfo = typeof(ISupportsPagination).GetProperties()
                                                               .Where(p => p.Name == "Limit")
                                                               .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }
    }
}
