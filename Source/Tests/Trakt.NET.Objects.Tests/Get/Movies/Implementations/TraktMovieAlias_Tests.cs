namespace TraktNet.Objects.Tests.Get.Movies.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.Implementations")]
    public class TraktMovieAlias_Tests
    {
        [Fact]
        public void Test_TraktMovieAlias_Default_Constructor()
        {
            var movieAlias = new TraktMovieAlias();

            movieAlias.Title.Should().BeNullOrEmpty();
            movieAlias.CountryCode.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktMovieAlias_From_Json()
        {
            var jsonReader = new MovieAliasObjectJsonReader();
            var movieAlias = await jsonReader.ReadObjectAsync(JSON) as TraktMovieAlias;

            movieAlias.Should().NotBeNull();
            movieAlias.Title.Should().Be("Star Wars: The Force Awakens");
            movieAlias.CountryCode.Should().Be("us");
        }

        private const string JSON =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""country"": ""us""
              }";
    }
}
