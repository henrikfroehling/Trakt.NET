namespace TraktNet.Tests.Objects.Post.Responses.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundShowArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundShowArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new PostResponseNotFoundShowArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var notFoundShows = await jsonReader.ReadArrayAsync(stream);
                notFoundShows.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundShowArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new PostResponseNotFoundShowArrayJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var notFoundShows = await jsonReader.ReadArrayAsync(stream);
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
        public async Task Test_PostResponseNotFoundShowArrayJsonReader_ReadArray_From_Stream_Not_Valid()
        {
            var jsonReader = new PostResponseNotFoundShowArrayJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var notFoundShows = await jsonReader.ReadArrayAsync(stream);
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
        public async Task Test_PostResponseNotFoundShowArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new PostResponseNotFoundShowArrayJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadArrayAsync(default(Stream));
            traktShowCollectionProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundShowArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new PostResponseNotFoundShowArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktShowCollectionProgress = await jsonReader.ReadArrayAsync(stream);
                traktShowCollectionProgress.Should().BeNull();
            }
        }
    }
}
