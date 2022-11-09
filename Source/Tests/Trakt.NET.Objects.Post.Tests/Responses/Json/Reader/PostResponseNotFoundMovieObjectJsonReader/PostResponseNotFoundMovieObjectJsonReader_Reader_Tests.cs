﻿namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new PostResponseNotFoundMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                postResponseNotFoundMovie.Should().NotBeNull();
                postResponseNotFoundMovie.Ids.Should().NotBeNull();
                postResponseNotFoundMovie.Ids.Trakt.Should().Be(94024U);
                postResponseNotFoundMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                postResponseNotFoundMovie.Ids.Imdb.Should().Be("tt2488496");
                postResponseNotFoundMovie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new PostResponseNotFoundMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                postResponseNotFoundMovie.Should().NotBeNull();
                postResponseNotFoundMovie.Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new PostResponseNotFoundMovieObjectJsonReader();
            Func<Task<ITraktPostResponseNotFoundMovie>> postResponseNotFoundMovie = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await postResponseNotFoundMovie.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new PostResponseNotFoundMovieObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundMovie = await traktJsonReader.ReadObjectAsync(jsonReader);
                postResponseNotFoundMovie.Should().BeNull();
            }
        }
    }
}
