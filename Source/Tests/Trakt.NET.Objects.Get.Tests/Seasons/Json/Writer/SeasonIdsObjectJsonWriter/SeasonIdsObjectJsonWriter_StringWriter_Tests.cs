namespace TraktNet.Objects.Get.Tests.Seasons.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Seasons.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonWriter")]
    public partial class SeasonIdsObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_SeasonIdsObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new SeasonIdsObjectJsonWriter();
            ITraktSeasonIds traktSeasonIds = new TraktSeasonIds();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktSeasonIds);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonWriter_WriteObject_StringWriter_Only_Trakt_Property()
        {
            ITraktSeasonIds traktSeasonIds = new TraktSeasonIds
            {
                Trakt = 123
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonIdsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeasonIds);
                json.Should().Be(@"{""trakt"":123}");
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonWriter_WriteObject_StringWriter_Only_Tvdb_Property()
        {
            ITraktSeasonIds traktSeasonIds = new TraktSeasonIds
            {
                Tvdb = 456
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonIdsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeasonIds);
                json.Should().Be(@"{""trakt"":0,""tvdb"":456}");
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonWriter_WriteObject_StringWriter_Only_Tmdb_Property()
        {
            ITraktSeasonIds traktSeasonIds = new TraktSeasonIds
            {
                Tmdb = 789
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonIdsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeasonIds);
                json.Should().Be(@"{""trakt"":0,""tmdb"":789}");
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonWriter_WriteObject_StringWriter_Only_TvRage_Property()
        {
            ITraktSeasonIds traktSeasonIds = new TraktSeasonIds
            {
                TvRage = 101
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonIdsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeasonIds);
                json.Should().Be(@"{""trakt"":0,""tvrage"":101}");
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktSeasonIds traktSeasonIds = new TraktSeasonIds
            {
                Trakt = 123,
                Tvdb = 456,
                Tmdb = 789,
                TvRage = 101
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SeasonIdsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSeasonIds);
                json.Should().Be(@"{""trakt"":123,""tvdb"":456,""tmdb"":789,""tvrage"":101}");
            }
        }
    }
}
