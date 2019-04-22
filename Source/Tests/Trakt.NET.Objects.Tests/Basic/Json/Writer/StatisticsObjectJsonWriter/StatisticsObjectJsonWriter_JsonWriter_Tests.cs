namespace TraktNet.Objects.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class StatisticsObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_StatisticsObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new StatisticsObjectJsonWriter();
            ITraktStatistics traktStatistics = new TraktStatistics();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktStatistics);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_JsonWriter_Only_Watchers_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Watchers = 1
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktStatistics);
                stringWriter.ToString().Should().Be(@"{""watchers"":1}");
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_JsonWriter_Only_Plays_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Plays = 2
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktStatistics);
                stringWriter.ToString().Should().Be(@"{""plays"":2}");
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_JsonWriter_Only_Collectors_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Collectors = 3
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktStatistics);
                stringWriter.ToString().Should().Be(@"{""collectors"":3}");
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_JsonWriter_Only_CollectedEpisodes_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                CollectedEpisodes = 4
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktStatistics);
                stringWriter.ToString().Should().Be(@"{""collected_episodes"":4}");
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_JsonWriter_Only_Comments_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Comments = 5
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktStatistics);
                stringWriter.ToString().Should().Be(@"{""comments"":5}");
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_JsonWriter_Only_Lists_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Lists = 6
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktStatistics);
                stringWriter.ToString().Should().Be(@"{""lists"":6}");
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_JsonWriter_Only_Votes_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Votes = 7
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktStatistics);
                stringWriter.ToString().Should().Be(@"{""votes"":7}");
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Watchers = 1,
                Plays = 2,
                Collectors = 3,
                CollectedEpisodes = 4,
                Comments = 5,
                Lists = 6,
                Votes = 7
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktStatistics);
                stringWriter.ToString().Should().Be(@"{""watchers"":1,""plays"":2,""collectors"":3," +
                                                    @"""collected_episodes"":4,""comments"":5,""lists"":6,""votes"":7}");
            }
        }
    }
}
