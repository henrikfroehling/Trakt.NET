﻿namespace TraktNet.Objects.Post.Tests.Responses.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Responses.Implementations")]
    public class TraktPostResponseNotFoundMovie_Tests
    {
        [Fact]
        public void Test_TraktPostResponseNotFoundMovie_Default_Constructor()
        {
            var postResponseNotFoundMovie = new TraktPostResponseNotFoundMovie();

            postResponseNotFoundMovie.Ids.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundMovie_From_Json()
        {
            var jsonReader = new PostResponseNotFoundMovieObjectJsonReader();
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
