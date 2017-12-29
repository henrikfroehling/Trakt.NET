namespace TraktApiSharp.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class StatisticsObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_StatisticsObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new StatisticsObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktStatistics));
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_Object_Only_Watchers_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Watchers = 1
            };

            var traktJsonWriter = new StatisticsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktStatistics);
            json.Should().Be(@"{""watchers"":1}");
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_Object_Only_Plays_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Plays = 2
            };

            var traktJsonWriter = new StatisticsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktStatistics);
            json.Should().Be(@"{""plays"":2}");
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_Object_Only_Collectors_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Collectors = 3
            };

            var traktJsonWriter = new StatisticsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktStatistics);
            json.Should().Be(@"{""collectors"":3}");
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_Object_Only_CollectedEpisodes_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                CollectedEpisodes = 4
            };

            var traktJsonWriter = new StatisticsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktStatistics);
            json.Should().Be(@"{""collected_episodes"":4}");
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_Object_Only_Comments_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Comments = 5
            };

            var traktJsonWriter = new StatisticsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktStatistics);
            json.Should().Be(@"{""comments"":5}");
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_Object_Only_Lists_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Lists = 6
            };

            var traktJsonWriter = new StatisticsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktStatistics);
            json.Should().Be(@"{""lists"":6}");
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_Object_Only_Votes_Property()
        {
            ITraktStatistics traktStatistics = new TraktStatistics
            {
                Votes = 7
            };

            var traktJsonWriter = new StatisticsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktStatistics);
            json.Should().Be(@"{""votes"":7}");
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonWriter_WriteObject_Object_Complete()
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

            var traktJsonWriter = new StatisticsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktStatistics);
            json.Should().Be(@"{""watchers"":1,""plays"":2,""collectors"":3," +
                             @"""collected_episodes"":4,""comments"":5,""lists"":6,""votes"":7}");
        }
    }
}
