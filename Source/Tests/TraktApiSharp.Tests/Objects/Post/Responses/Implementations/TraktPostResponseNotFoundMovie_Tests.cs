namespace TraktApiSharp.Tests.Objects.Post.Responses.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Responses.Implementations;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.Implementations")]
    public class TraktPostResponseNotFoundMovie_Tests
    {
        [Fact]
        public void Test_TraktPostResponseNotFoundMovie_Implements_ITraktPostResponseNotFoundMovie_Interface()
        {
            typeof(TraktPostResponseNotFoundMovie).GetInterfaces().Should().Contain(typeof(ITraktPostResponseNotFoundMovie));
        }

        [Fact]
        public void Test_TraktPostResponseNotFoundMovie_Default_Constructor()
        {
            var postResponseNotFoundMovie = new TraktPostResponseNotFoundMovie();

            postResponseNotFoundMovie.Ids.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundMovie_From_Json()
        {
            var jsonReader = new TraktPostResponseNotFoundMovieObjectJsonReader();
            var postResponseNotFoundMovie = await jsonReader.ReadObjectAsync(JSON) as TraktPostResponseNotFoundMovie;

            postResponseNotFoundMovie.Should().NotBeNull();
            postResponseNotFoundMovie.Ids.Should().NotBeNull();
            postResponseNotFoundMovie.Ids.Trakt.Should().Be(94024U);
            postResponseNotFoundMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            postResponseNotFoundMovie.Ids.Imdb.Should().Be("tt2488496");
            postResponseNotFoundMovie.Ids.Tmdb.Should().Be(140607U);
        }

        private const string JSON =
            @"{
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";
    }
}
