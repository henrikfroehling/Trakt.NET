namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Interfaces")]
    public class ISupportsExtendedInfo_Tests
    {
        [Fact]
        public void Test_ISupportsExtendedInfo_Is_Interface()
        {
            typeof(ISupportsExtendedInfo).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ISupportsExtendedInfo_Has_ExtendedInfo_Property()
        {
            var propertyInfo = typeof(ISupportsExtendedInfo).GetProperties()
                                                                 .Where(p => p.Name == "ExtendedInfo")
                                                                 .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktExtendedInfo));
        }
    }
}
