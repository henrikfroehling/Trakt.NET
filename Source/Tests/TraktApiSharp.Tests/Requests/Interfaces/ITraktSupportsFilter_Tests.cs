namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Interfaces")]
    public class ITraktSupportsFilter_Tests
    {
        [Fact]
        public void Test_ITraktSupportsFilter_Is_Interface()
        {
            typeof(ITraktSupportsFilter).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSupportsFilter_Has_Filter_Property()
        {
            var propertyInfo = typeof(ITraktSupportsFilter).GetProperties()
                                                           .Where(p => p.Name == "Filter")
                                                           .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktCommonFilter));
        }
    }
}
