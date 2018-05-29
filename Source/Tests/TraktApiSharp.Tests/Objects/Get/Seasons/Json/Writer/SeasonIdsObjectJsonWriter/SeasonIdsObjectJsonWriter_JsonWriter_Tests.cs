namespace TraktApiSharp.Tests.Objects.Get.Seasons.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonWriter")]
    public partial class SeasonIdsObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_SeasonIdsObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new SeasonIdsObjectJsonWriter();
            ITraktSeasonIds traktSeasonIds = new TraktSeasonIds();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktSeasonIds);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonWriter_WriteObject_JsonWriter_Only_Trakt_Property()
        {
            ITraktSeasonIds traktSeasonIds = new TraktSeasonIds
            {
                Trakt = 123
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SeasonIdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSeasonIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":123}");
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonWriter_WriteObject_JsonWriter_Only_Tvdb_Property()
        {
            ITraktSeasonIds traktSeasonIds = new TraktSeasonIds
            {
                Tvdb = 456
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SeasonIdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSeasonIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":0,""tvdb"":456}");
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonWriter_WriteObject_JsonWriter_Only_Tmdb_Property()
        {
            ITraktSeasonIds traktSeasonIds = new TraktSeasonIds
            {
                Tmdb = 789
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SeasonIdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSeasonIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":0,""tmdb"":789}");
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonWriter_WriteObject_JsonWriter_Only_TvRage_Property()
        {
            ITraktSeasonIds traktSeasonIds = new TraktSeasonIds
            {
                TvRage = 101
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SeasonIdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSeasonIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":0,""tvrage"":101}");
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktSeasonIds traktSeasonIds = new TraktSeasonIds
            {
                Trakt = 123,
                Tvdb = 456,
                Tmdb = 789,
                TvRage = 101
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SeasonIdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSeasonIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":123,""tvdb"":456,""tmdb"":789,""tvrage"":101}");
            }
        }
    }
}
