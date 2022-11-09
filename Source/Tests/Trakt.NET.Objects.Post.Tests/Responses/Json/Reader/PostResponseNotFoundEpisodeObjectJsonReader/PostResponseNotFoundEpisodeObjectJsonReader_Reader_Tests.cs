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
    public partial class PostResponseNotFoundEpisodeObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new PostResponseNotFoundEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                postResponseNotFoundEpisode.Should().NotBeNull();
                postResponseNotFoundEpisode.Ids.Should().NotBeNull();
                postResponseNotFoundEpisode.Ids.Trakt.Should().Be(73640U);
                postResponseNotFoundEpisode.Ids.Tvdb.Should().Be(3254641U);
                postResponseNotFoundEpisode.Ids.Imdb.Should().Be("tt1480055");
                postResponseNotFoundEpisode.Ids.Tmdb.Should().Be(63056U);
                postResponseNotFoundEpisode.Ids.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new PostResponseNotFoundEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                postResponseNotFoundEpisode.Should().NotBeNull();
                postResponseNotFoundEpisode.Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new PostResponseNotFoundEpisodeObjectJsonReader();
            Func<Task<ITraktPostResponseNotFoundEpisode>> postResponseNotFoundEpisode = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await postResponseNotFoundEpisode.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new PostResponseNotFoundEpisodeObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);
                postResponseNotFoundEpisode.Should().BeNull();
            }
        }
    }
}
