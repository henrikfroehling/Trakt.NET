namespace TraktNet.Objects.Get.Tests.Episodes.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeIdsArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_EpisodeIdsArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeIds>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktEpisodeIds> traktEpisodeIds = new List<TraktEpisodeIds>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeIds>();
            string json = await traktJsonWriter.WriteArrayAsync(traktEpisodeIds);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktEpisodeIds> traktEpisodeIds = new List<ITraktEpisodeIds>
            {
                new TraktEpisodeIds
                {
                    Trakt = 123,
                    Tvdb = 456,
                    Imdb = "ids imdb",
                    Tmdb = 789,
                    TvRage = 101
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeIds>();
            string json = await traktJsonWriter.WriteArrayAsync(traktEpisodeIds);
            json.Should().Be(@"[{""trakt"":123,""tvdb"":456," +
                             @"""imdb"":""ids imdb"",""tmdb"":789,""tvrage"":101}]");
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktEpisodeIds> traktEpisodeIds = new List<ITraktEpisodeIds>
            {
                new TraktEpisodeIds
                {
                    Trakt = 123,
                    Tvdb = 456,
                    Imdb = "ids imdb",
                    Tmdb = 789,
                    TvRage = 101
                },
                new TraktEpisodeIds
                {
                    Trakt = 123,
                    Tvdb = 456,
                    Imdb = "ids imdb",
                    Tmdb = 789,
                    TvRage = 101
                },
                new TraktEpisodeIds
                {
                    Trakt = 123,
                    Tvdb = 456,
                    Imdb = "ids imdb",
                    Tmdb = 789,
                    TvRage = 101
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeIds>();
            string json = await traktJsonWriter.WriteArrayAsync(traktEpisodeIds);
            json.Should().Be(@"[{""trakt"":123,""tvdb"":456," +
                             @"""imdb"":""ids imdb"",""tmdb"":789,""tvrage"":101}," +
                             @"{""trakt"":123,""tvdb"":456," +
                             @"""imdb"":""ids imdb"",""tmdb"":789,""tvrage"":101}," +
                             @"{""trakt"":123,""tvdb"":456," +
                             @"""imdb"":""ids imdb"",""tmdb"":789,""tvrage"":101}]");
        }
    }
}
