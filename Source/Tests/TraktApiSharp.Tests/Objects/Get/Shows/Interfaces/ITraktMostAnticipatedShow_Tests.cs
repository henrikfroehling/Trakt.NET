namespace TraktApiSharp.Tests.Objects.Get.Shows.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Shows.Interfaces")]
    public class ITraktMostAnticipatedShow_Tests
    {
        [Fact]
        public void Test_ITraktMostAnticipatedShow_Is_Interface()
        {
            typeof(ITraktMostAnticipatedShow).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShow_Inherits_ITraktShow_Interface()
        {
            typeof(ITraktMostAnticipatedShow).GetInterfaces().Should().Contain(typeof(ITraktShow));
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShow_Has_ListCount_Property()
        {
            var propertyInfo = typeof(ITraktMostAnticipatedShow).GetProperties().FirstOrDefault(p => p.Name == "ListCount");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShow_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktMostAnticipatedShow).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }
    }
}
