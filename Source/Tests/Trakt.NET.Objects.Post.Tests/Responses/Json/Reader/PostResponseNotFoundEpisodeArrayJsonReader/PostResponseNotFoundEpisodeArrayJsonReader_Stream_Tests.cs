namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundEpisodeArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new PostResponseNotFoundEpisodeArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var notFoundEpisodes = await jsonReader.ReadArrayAsync(stream);
                notFoundEpisodes.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new PostResponseNotFoundEpisodeArrayJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var notFoundEpisodes = await jsonReader.ReadArrayAsync(stream);
                notFoundEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var notFoundEpisode = notFoundEpisodes.ToArray();

                notFoundEpisode[0].Should().NotBeNull();
                notFoundEpisode[0].Ids.Should().NotBeNull();
                notFoundEpisode[0].Ids.Trakt.Should().Be(73640U);
                notFoundEpisode[0].Ids.Tvdb.Should().Be(3254641U);
                notFoundEpisode[0].Ids.Imdb.Should().Be("tt1480055");
                notFoundEpisode[0].Ids.Tmdb.Should().Be(63056U);
                notFoundEpisode[0].Ids.TvRage.Should().Be(1065008299U);

                notFoundEpisode[1].Should().NotBeNull();
                notFoundEpisode[1].Ids.Should().NotBeNull();
                notFoundEpisode[1].Ids.Trakt.Should().Be(73641U);
                notFoundEpisode[1].Ids.Tvdb.Should().Be(3436411U);
                notFoundEpisode[1].Ids.Imdb.Should().Be("tt1668746");
                notFoundEpisode[1].Ids.Tmdb.Should().Be(63057U);
                notFoundEpisode[1].Ids.TvRage.Should().Be(1065023912U);
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeArrayJsonReader_ReadArray_From_Stream_Not_Valid()
        {
            var jsonReader = new PostResponseNotFoundEpisodeArrayJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var notFoundEpisodes = await jsonReader.ReadArrayAsync(stream);
                notFoundEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var notFoundEpisode = notFoundEpisodes.ToArray();

                notFoundEpisode[0].Should().NotBeNull();
                notFoundEpisode[0].Ids.Should().NotBeNull();
                notFoundEpisode[0].Ids.Trakt.Should().Be(73640U);
                notFoundEpisode[0].Ids.Tvdb.Should().Be(3254641U);
                notFoundEpisode[0].Ids.Imdb.Should().Be("tt1480055");
                notFoundEpisode[0].Ids.Tmdb.Should().Be(63056U);
                notFoundEpisode[0].Ids.TvRage.Should().Be(1065008299U);

                notFoundEpisode[1].Should().NotBeNull();
                notFoundEpisode[1].Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new PostResponseNotFoundEpisodeArrayJsonReader();

            var notFoundEpisodes = await jsonReader.ReadArrayAsync(default(Stream));
            notFoundEpisodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new PostResponseNotFoundEpisodeArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var notFoundEpisodes = await jsonReader.ReadArrayAsync(stream);
                notFoundEpisodes.Should().BeNull();
            }
        }
    }
}
