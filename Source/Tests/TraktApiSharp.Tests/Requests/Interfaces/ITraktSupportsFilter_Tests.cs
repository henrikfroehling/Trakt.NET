namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Tests.Traits;
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
            var filterPropertyInfo = typeof(ITraktSupportsFilter).GetProperties()
                                                                 .Where(p => p.Name == "Filter")
                                                                 .FirstOrDefault();

            filterPropertyInfo.CanRead.Should().BeTrue();
            filterPropertyInfo.CanWrite.Should().BeTrue();
            filterPropertyInfo.PropertyType.Should().Be(typeof(TraktCommonFilter));
        }
    }
}
