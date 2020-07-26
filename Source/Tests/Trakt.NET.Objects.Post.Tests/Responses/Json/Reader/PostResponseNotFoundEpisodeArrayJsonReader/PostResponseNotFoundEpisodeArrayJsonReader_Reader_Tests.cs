namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Responses;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundEpisodeArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundEpisode>();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundEpisodes.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundEpisode>();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_PostResponseNotFoundEpisodeArrayJsonReader_ReadArray_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundEpisode>();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_PostResponseNotFoundEpisodeArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundEpisode>();

            var notFoundEpisodes = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            notFoundEpisodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundEpisodeArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundEpisode>();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundEpisodes.Should().BeNull();
            }
        }
    }
}
