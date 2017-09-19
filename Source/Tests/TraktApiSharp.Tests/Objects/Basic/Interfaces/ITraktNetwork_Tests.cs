namespace TraktApiSharp.Tests.Objects.Basic.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class ITraktNetwork_Tests
    {
        [Fact]
        public void Test_ITraktNetwork_Is_Interface()
        {
            typeof(ITraktNetwork).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktNetwork_Has_Network_Property()
        {
            var propertyInfo = typeof(ITraktNetwork).GetProperties().FirstOrDefault(p => p.Name == "Network");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
