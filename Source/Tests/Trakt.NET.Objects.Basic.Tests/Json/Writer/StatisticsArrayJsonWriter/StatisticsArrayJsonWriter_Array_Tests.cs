namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class StatisticsArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_StatisticsArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktStatistics>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_StatisticsArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktStatistics> traktStatistics = new List<TraktStatistics>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktStatistics>();
            string json = await traktJsonWriter.WriteArrayAsync(traktStatistics);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_StatisticsArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktStatistics> traktStatistics = new List<ITraktStatistics>
            {
                new TraktStatistics
                {
                    Watchers = 1,
                    Plays = 2,
                    Collectors = 3,
                    CollectedEpisodes = 4,
                    Comments = 5,
                    Lists = 6,
                    Votes = 7
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktStatistics>();
            string json = await traktJsonWriter.WriteArrayAsync(traktStatistics);
            json.Should().Be(@"[{""watchers"":1,""plays"":2,""collectors"":3," +
                             @"""collected_episodes"":4,""comments"":5,""lists"":6,""votes"":7}]");
        }

        [Fact]
        public async Task Test_StatisticsArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktStatistics> traktStatistics = new List<ITraktStatistics>
            {
                new TraktStatistics
                {
                    Watchers = 1,
                    Plays = 2,
                    Collectors = 3,
                    CollectedEpisodes = 4,
                    Comments = 5,
                    Lists = 6,
                    Votes = 7
                },
                new TraktStatistics
                {
                    Watchers = 1,
                    Plays = 2,
                    Collectors = 3,
                    CollectedEpisodes = 4,
                    Comments = 5,
                    Lists = 6,
                    Votes = 7
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktStatistics>();
            string json = await traktJsonWriter.WriteArrayAsync(traktStatistics);
            json.Should().Be(@"[{""watchers"":1,""plays"":2,""collectors"":3," +
                             @"""collected_episodes"":4,""comments"":5,""lists"":6,""votes"":7}," +
                             @"{""watchers"":1,""plays"":2,""collectors"":3," +
                             @"""collected_episodes"":4,""comments"":5,""lists"":6,""votes"":7}]");
        }
    }
}
