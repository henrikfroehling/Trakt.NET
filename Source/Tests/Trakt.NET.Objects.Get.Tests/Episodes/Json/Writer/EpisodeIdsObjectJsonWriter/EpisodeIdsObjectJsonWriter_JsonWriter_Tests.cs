﻿namespace TraktNet.Objects.Get.Tests.Episodes.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Episodes.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeIdsObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktEpisodeIds);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_JsonWriter_Only_Trakt_Property()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                Trakt = 123
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":123}");
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_JsonWriter_Only_Tvdb_Property()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                Tvdb = 456
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":0,""tvdb"":456}");
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_JsonWriter_Only_Imdb_Property()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                Imdb = "ids imdb"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":0,""imdb"":""ids imdb""}");
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_JsonWriter_Only_Tmdb_Property()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                Tmdb = 789
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":0,""tmdb"":789}");
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_JsonWriter_Only_TvRage_Property()
        {
            ITraktEpisodeIds traktEpisodeIds = new TraktEpisodeIds
            {
                TvRage = 101
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":0,""tvrage"":101}");
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonWriter_WriteObject_JsonWriter_Complete()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeIdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":123,""tvdb"":456," +
                                                    @"""imdb"":""ids imdb"",""tmdb"":789,""tvrage"":101}");
            }
        }
    }
}
