namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Interfaces")]
    public class ITraktUserNetworkStatistics_Tests
    {
        [Fact]
        public void Test_ITraktUserNetworkStatistics_Is_Interface()
        {
            typeof(ITraktUserNetworkStatistics).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserNetworkStatistics_Has_Friends_Property()
        {
            var propertyInfo = typeof(ITraktUserNetworkStatistics).GetProperties().FirstOrDefault(p => p.Name == "Friends");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktUserNetworkStatistics_Has_Followers_Property()
        {
            var propertyInfo = typeof(ITraktUserNetworkStatistics).GetProperties().FirstOrDefault(p => p.Name == "Followers");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktUserNetworkStatistics_Has_Following_Property()
        {
            var propertyInfo = typeof(ITraktUserNetworkStatistics).GetProperties().FirstOrDefault(p => p.Name == "Following");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }
    }
}
