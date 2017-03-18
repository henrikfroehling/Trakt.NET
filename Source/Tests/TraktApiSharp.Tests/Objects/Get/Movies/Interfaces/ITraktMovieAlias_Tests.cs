namespace TraktApiSharp.Tests.Objects.Get.Movies.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies.Interfaces")]
    public class ITraktMovieAliasAlias_Tests
    {
        [Fact]
        public void Test_ITraktMovieAlias_Is_Interface()
        {
            typeof(ITraktMovieAlias).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktMovieAlias_Has_Title_Property()
        {
            var propertyInfo = typeof(ITraktMovieAlias).GetProperties().FirstOrDefault(p => p.Name == "Title");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktMovieAlias_Has_CountryCode_Property()
        {
            var propertyInfo = typeof(ITraktMovieAlias).GetProperties().FirstOrDefault(p => p.Name == "CountryCode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
