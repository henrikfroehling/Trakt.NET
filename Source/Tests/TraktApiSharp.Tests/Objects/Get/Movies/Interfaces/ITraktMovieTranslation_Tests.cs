namespace TraktApiSharp.Tests.Objects.Get.Movies.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies.Interfaces")]
    public class ITraktMovieTranslation_Tests
    {
        [Fact]
        public void Test_ITraktMovieTranslation_Is_Interface()
        {
            typeof(ITraktMovieTranslation).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktMovieTranslation_Inherits_ITraktTranslation_Interface()
        {
            typeof(ITraktMovieTranslation).GetInterfaces().Should().Contain(typeof(ITraktTranslation));
        }

        [Fact]
        public void Test_ITraktMovieTranslation_Has_Tagline_Property()
        {
            var propertyInfo = typeof(ITraktMovieTranslation).GetProperties().FirstOrDefault(p => p.Name == "Tagline");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
