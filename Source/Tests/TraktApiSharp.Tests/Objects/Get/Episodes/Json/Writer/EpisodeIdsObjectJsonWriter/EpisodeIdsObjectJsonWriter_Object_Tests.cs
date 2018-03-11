namespace TraktApiSharp.Tests.Objects.Get.Episodes.Json.Writer
{
    using FluentAssertions;
    using System;
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
        public void Test_EpisodeIdsObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktEpisodeIds));
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_Object_Only_Trakt_Property()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                Trakt = 123
            };

            var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeIds);
            json.Should().Be(@"{""trakt"":123}");
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_Object_Only_Tvdb_Property()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                Tvdb = 456
            };

            var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeIds);
            json.Should().Be(@"{""trakt"":0,""tvdb"":456}");
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_Object_Only_Imdb_Property()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                Imdb = "ids imdb"
            };

            var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeIds);
            json.Should().Be(@"{""trakt"":0,""imdb"":""ids imdb""}");
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_Object_Only_Tmdb_Property()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                Tmdb = 789
            };

            var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeIds);
            json.Should().Be(@"{""trakt"":0,""tmdb"":789}");
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_Object_Only_TvRage_Property()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                TvRage = 101
            };

            var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeIds);
            json.Should().Be(@"{""trakt"":0,""tvrage"":101}");
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                Trakt = 123,
                Tvdb = 456,
                Imdb = "ids imdb",
                Tmdb = 789,
                TvRage = 101
            };

            var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeIds);
            json.Should().Be(@"{""trakt"":123,""tvdb"":456," +
                             @"""imdb"":""ids imdb"",""tmdb"":789,""tvrage"":101}");
        }
    }
}
