namespace TraktApiSharp.Tests.Objects.Get.Episodes.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Get.Episodes.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeIdsObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_EpisodeIdsObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktEpisodeIds);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_StringWriter_Only_Trakt_Property()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                Trakt = 123
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeIds);
                json.Should().Be(@"{""trakt"":123}");
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_StringWriter_Only_Tvdb_Property()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                Tvdb = 456
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeIds);
                json.Should().Be(@"{""trakt"":0,""tvdb"":456}");
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_StringWriter_Only_Imdb_Property()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                Imdb = "ids imdb"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeIds);
                json.Should().Be(@"{""trakt"":0,""imdb"":""ids imdb""}");
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_StringWriter_Only_Tmdb_Property()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                Tmdb = 789
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeIds);
                json.Should().Be(@"{""trakt"":0,""tmdb"":789}");
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_StringWriter_Only_TvRage_Property()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                TvRage = 101
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeIds);
                json.Should().Be(@"{""trakt"":0,""tvrage"":101}");
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                Trakt = 123,
                Tvdb = 456,
                Imdb = "ids imdb",
                Tmdb = 789,
                TvRage = 101
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeIds);
                json.Should().Be(@"{""trakt"":123,""tvdb"":456," +
                                 @"""imdb"":""ids imdb"",""tmdb"":789,""tvrage"":101}");
            }
        }
    }
}
