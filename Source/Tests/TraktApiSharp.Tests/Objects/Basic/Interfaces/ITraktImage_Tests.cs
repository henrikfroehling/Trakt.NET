namespace TraktApiSharp.Tests.Objects.Basic.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class ITraktImage_Tests
    {
        [Fact]
        public void Test_ITraktImage_Is_Interface()
        {
            typeof(ITraktImage).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktImage_Has_Full_Property()
        {
            var propertyInfo = typeof(ITraktImage).GetProperties().FirstOrDefault(p => p.Name == "Full");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
