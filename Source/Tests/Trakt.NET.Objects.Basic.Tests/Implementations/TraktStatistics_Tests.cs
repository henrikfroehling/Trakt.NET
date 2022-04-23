﻿namespace TraktNet.Objects.Basic.Tests.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktStatistics_Tests
    {
        [Fact]
        public void Test_TraktStatistics_Default_Constructor()
        {
            var traktStatistics = new TraktStatistics();

            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().BeNull();
            traktStatistics.Recommended.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktStatistics_From_Json()
        {
            var jsonReader = new StatisticsObjectJsonReader();
            var traktStatistics = await jsonReader.ReadObjectAsync(JSON) as TraktStatistics;

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
            traktStatistics.Recommended.Should().Be(54321);
        }

        private const string JSON =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274,
                ""recommended"": 54321
              }";
    }
}
