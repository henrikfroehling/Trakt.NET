namespace TraktApiSharp.Tests.Objects.Get.Movies.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.Implementations;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.Implementations")]
    public class TraktMovieAlias_Tests
    {
        [Fact]
        public void Test_TraktMovieAlias_Implements_ITraktMovieAlias_Interface()
        {
            typeof(TraktMovieAlias).GetInterfaces().Should().Contain(typeof(ITraktMovieAlias));
        }

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
            var jsonReader = new TraktMovieAliasObjectJsonReader();
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
