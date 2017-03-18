namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Interfaces
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Interfaces")]
    public class ITraktUserRatingsStatistics_Tests
    {
        [Fact]
        public void Test_ITraktUserRatingsStatistics_Is_Interface()
        {
            typeof(ITraktUserRatingsStatistics).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserRatingsStatistics_Has_Total_Property()
        {
            var propertyInfo = typeof(ITraktUserRatingsStatistics).GetProperties().FirstOrDefault(p => p.Name == "Total");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktUserRatingsStatistics_Has_Distribution_Property()
        {
            var propertyInfo = typeof(ITraktUserRatingsStatistics).GetProperties().FirstOrDefault(p => p.Name == "Distribution");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IDictionary<string, int>));
        }
    }
}
