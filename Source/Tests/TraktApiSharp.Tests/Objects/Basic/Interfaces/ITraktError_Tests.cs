namespace TraktApiSharp.Tests.Objects.Basic.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class ITraktError_Tests
    {
        [Fact]
        public void Test_ITraktError_Is_Interface()
        {
            typeof(ITraktError).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktError_Has_Error_Property()
        {
            var propertyInfo = typeof(ITraktError).GetProperties().FirstOrDefault(p => p.Name == "Error");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktError_Has_Description_Property()
        {
            var propertyInfo = typeof(ITraktError).GetProperties().FirstOrDefault(p => p.Name == "Description");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
