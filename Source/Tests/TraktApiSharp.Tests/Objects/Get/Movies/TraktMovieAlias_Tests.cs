namespace TraktApiSharp.Tests.Objects.Get.Movies
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies")]
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
        public void Test_TraktMovieAlias_From_Json()
        {
            var movieAlias = JsonConvert.DeserializeObject<TraktMovieAlias>(JSON);

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
