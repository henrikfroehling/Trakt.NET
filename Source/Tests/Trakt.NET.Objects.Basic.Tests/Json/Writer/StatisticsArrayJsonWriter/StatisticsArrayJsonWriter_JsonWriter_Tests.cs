﻿namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class StatisticsArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_StatisticsArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktStatistics>();
            IEnumerable<ITraktStatistics> traktStatistics = new List<TraktStatistics>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktStatistics);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_StatisticsArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktStatistics> traktStatistics = new List<TraktStatistics>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktStatistics>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktStatistics);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_StatisticsArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
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
                    Votes = 7,
                    Recommended = 8
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktStatistics>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktStatistics);
                stringWriter.ToString().Should().Be(@"[{""watchers"":1,""plays"":2,""collectors"":3," +
                                                    @"""collected_episodes"":4,""comments"":5,""lists"":6,""votes"":7,""recommended"":8}]");
            }
        }

        [Fact]
        public async Task Test_StatisticsArrayJsonWriter_WriteArray_JsonWriter_Complete()
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
                    Votes = 7,
                    Recommended = 8
                },
                new TraktStatistics
                {
                    Watchers = 1,
                    Plays = 2,
                    Collectors = 3,
                    CollectedEpisodes = 4,
                    Comments = 5,
                    Lists = 6,
                    Votes = 7,
                    Recommended = 8
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktStatistics>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktStatistics);
                stringWriter.ToString().Should().Be(@"[{""watchers"":1,""plays"":2,""collectors"":3," +
                                                    @"""collected_episodes"":4,""comments"":5,""lists"":6,""votes"":7,""recommended"":8}," +
                                                    @"{""watchers"":1,""plays"":2,""collectors"":3," +
                                                    @"""collected_episodes"":4,""comments"":5,""lists"":6,""votes"":7,""recommended"":8}]");
            }
        }
    }
}
