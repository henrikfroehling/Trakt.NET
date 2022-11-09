namespace TraktNet.Objects.Get.Tests.Episodes.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeIdsArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_EpisodeIdsArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeIds>();
            IEnumerable<ITraktEpisodeIds> traktEpisodeIds = new List<TraktEpisodeIds>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktEpisodeIds);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktEpisodeIds> traktEpisodeIds = new List<TraktEpisodeIds>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeIds>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktEpisodeIds);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
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

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeIds>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktEpisodeIds);
                stringWriter.ToString().Should().Be(@"[{""trakt"":123,""tvdb"":456," +
                                                    @"""imdb"":""ids imdb"",""tmdb"":789,""tvrage"":101}]");
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonWriter_WriteArray_JsonWriter_Complete()
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

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeIds>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktEpisodeIds);
                stringWriter.ToString().Should().Be(@"[{""trakt"":123,""tvdb"":456," +
                                                    @"""imdb"":""ids imdb"",""tmdb"":789,""tvrage"":101}," +
                                                    @"{""trakt"":123,""tvdb"":456," +
                                                    @"""imdb"":""ids imdb"",""tmdb"":789,""tvrage"":101}," +
                                                    @"{""trakt"":123,""tvdb"":456," +
                                                    @"""imdb"":""ids imdb"",""tmdb"":789,""tvrage"":101}]");
            }
        }
    }
}
