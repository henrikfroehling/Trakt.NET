namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Responses;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundShowArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundShowArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundShow>();

            var notFoundShows = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            notFoundShows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundShowArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundShow>();

            var notFoundShows = await jsonReader.ReadArrayAsync(JSON_COMPLETE);
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

        [Fact]
        public async Task Test_PostResponseNotFoundShowArrayJsonReader_ReadArray_From_Json_String_Not_Valid()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundShow>();

            var notFoundShows = await jsonReader.ReadArrayAsync(JSON_NOT_VALID);
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

        [Fact]
        public async Task Test_PostResponseNotFoundShowArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundShow>();
            Func<Task<IEnumerable<ITraktPostResponseNotFoundShow>>> notFoundShows = () => jsonReader.ReadArrayAsync(default(string));
            await notFoundShows.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundShowArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundShow>();

            var notFoundShows = await jsonReader.ReadArrayAsync(string.Empty);
            notFoundShows.Should().BeNull();
        }
    }
}
