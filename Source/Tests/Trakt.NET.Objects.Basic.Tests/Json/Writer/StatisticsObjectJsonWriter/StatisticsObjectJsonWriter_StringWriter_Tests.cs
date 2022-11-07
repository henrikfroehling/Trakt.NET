namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class StatisticsObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new StatisticsObjectJsonWriter();
            ITraktStatistics traktStatistics = new TraktStatistics();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktStatistics);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_StringWriter_Only_Watchers_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Watchers = 1
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktStatistics);
                json.Should().Be(@"{""watchers"":1}");
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_StringWriter_Only_Plays_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Plays = 2
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktStatistics);
                json.Should().Be(@"{""plays"":2}");
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_StringWriter_Only_Collectors_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Collectors = 3
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktStatistics);
                json.Should().Be(@"{""collectors"":3}");
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_StringWriter_Only_CollectedEpisodes_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                CollectedEpisodes = 4
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktStatistics);
                json.Should().Be(@"{""collected_episodes"":4}");
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_StringWriter_Only_Comments_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Comments = 5
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktStatistics);
                json.Should().Be(@"{""comments"":5}");
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_StringWriter_Only_Lists_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Lists = 6
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktStatistics);
                json.Should().Be(@"{""lists"":6}");
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_StringWriter_Only_Votes_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Votes = 7
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktStatistics);
                json.Should().Be(@"{""votes"":7}");
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_StringWriter_Only_Recommended_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Recommended = 8
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktStatistics);
                json.Should().Be(@"{""recommended"":8}");
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Watchers = 1,
                Plays = 2,
                Collectors = 3,
                CollectedEpisodes = 4,
                Comments = 5,
                Lists = 6,
                Votes = 7,
                Recommended = 8
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new StatisticsObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktStatistics);
                json.Should().Be(@"{""watchers"":1,""plays"":2,""collectors"":3," +
                                 @"""collected_episodes"":4,""comments"":5,""lists"":6,""votes"":7,""recommended"":8}");
            }
        }
    }
}
