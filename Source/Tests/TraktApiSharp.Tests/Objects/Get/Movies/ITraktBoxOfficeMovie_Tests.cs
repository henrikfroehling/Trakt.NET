namespace TraktApiSharp.Tests.Objects.Get.Movies
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies")]
    public class ITraktBoxOfficeMovie_Tests
    {
        [Fact]
        public void Test_ITraktBoxOfficeMovie_Is_Interface()
        {
            typeof(ITraktBoxOfficeMovie).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovie_Inherits_ITraktMovie_Interface()
        {
            typeof(ITraktBoxOfficeMovie).GetInterfaces().Should().Contain(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovie_Has_Revenue_Property()
        {
            var propertyInfo = typeof(ITraktBoxOfficeMovie).GetProperties().FirstOrDefault(p => p.Name == "Revenue");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktBoxOfficeMovie_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktBoxOfficeMovie).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }
    }
}
