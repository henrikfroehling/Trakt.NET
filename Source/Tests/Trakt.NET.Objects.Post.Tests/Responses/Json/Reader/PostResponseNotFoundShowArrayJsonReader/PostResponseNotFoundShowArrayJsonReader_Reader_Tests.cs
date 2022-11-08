﻿namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Responses;
    using Xunit;

    [TestCategory("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundShowArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundShowArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundShow>();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundShows = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundShows.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundShowArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundShow>();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundShows = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundShows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var notFoundShow = notFoundShows.ToArray();

                notFoundShow[0].Should().NotBeNull();
                notFoundShow[0].Ids.Should().NotBeNull();
                notFoundShow[0].Ids.Trakt.Should().Be(1390U);
                notFoundShow[0].Ids.Slug.Should().Be("game-of-thrones");
                notFoundShow[0].Ids.Tvdb.Should().Be(121361U);
                notFoundShow[0].Ids.Imdb.Should().Be("tt0944947");
                notFoundShow[0].Ids.Tmdb.Should().Be(1399U);
                notFoundShow[0].Ids.TvRage.Should().Be(24493U);

                notFoundShow[1].Should().NotBeNull();
                notFoundShow[1].Ids.Should().NotBeNull();
                notFoundShow[1].Ids.Trakt.Should().Be(60300U);
                notFoundShow[1].Ids.Slug.Should().Be("the-flash-2014");
                notFoundShow[1].Ids.Tvdb.Should().Be(279121U);
                notFoundShow[1].Ids.Imdb.Should().Be("tt3107288");
                notFoundShow[1].Ids.Tmdb.Should().Be(60735U);
                notFoundShow[1].Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundShowArrayJsonReader_ReadArray_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundShow>();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundShows = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundShows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var notFoundShow = notFoundShows.ToArray();

                notFoundShow[0].Should().NotBeNull();
                notFoundShow[0].Ids.Should().NotBeNull();
                notFoundShow[0].Ids.Trakt.Should().Be(1390U);
                notFoundShow[0].Ids.Slug.Should().Be("game-of-thrones");
                notFoundShow[0].Ids.Tvdb.Should().Be(121361U);
                notFoundShow[0].Ids.Imdb.Should().Be("tt0944947");
                notFoundShow[0].Ids.Tmdb.Should().Be(1399U);
                notFoundShow[0].Ids.TvRage.Should().Be(24493U);

                notFoundShow[1].Should().NotBeNull();
                notFoundShow[1].Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundShowArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundShow>();
            Func<Task<IEnumerable<ITraktPostResponseNotFoundShow>>> traktShowCollectionProgress = () => traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            await traktShowCollectionProgress.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundShowArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundShow>();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktShowCollectionProgress.Should().BeNull();
            }
        }
    }
}
