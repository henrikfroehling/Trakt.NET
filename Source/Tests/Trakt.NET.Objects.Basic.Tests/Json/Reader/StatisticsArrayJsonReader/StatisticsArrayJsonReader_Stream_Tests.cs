namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class StatisticsArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_StatisticsArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktStatistics>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IList<ITraktStatistics> traktStatisticss = await jsonReader.ReadArrayAsync(stream);
                traktStatisticss.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_StatisticsArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktStatistics>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IList<ITraktStatistics> traktStatisticss = await jsonReader.ReadArrayAsync(stream);

                traktStatisticss.Should().NotBeNull();
                ITraktStatistics[] statistics = traktStatisticss.ToArray();

                statistics[0].Should().NotBeNull();
                statistics[0].Watchers.Should().Be(129920);
                statistics[0].Plays.Should().Be(3563853);
                statistics[0].Collectors.Should().Be(49711);
                statistics[0].CollectedEpisodes.Should().Be(1310350);
                statistics[0].Comments.Should().Be(96);
                statistics[0].Lists.Should().Be(49468);
                statistics[0].Votes.Should().Be(9274);

                statistics[1].Should().NotBeNull();
                statistics[1].Watchers.Should().Be(129920);
                statistics[1].Plays.Should().Be(3563853);
                statistics[1].Collectors.Should().Be(49711);
                statistics[1].CollectedEpisodes.Should().Be(1310350);
                statistics[1].Comments.Should().Be(96);
                statistics[1].Lists.Should().Be(49468);
                statistics[1].Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktStatistics>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IList<ITraktStatistics> traktStatisticss = await jsonReader.ReadArrayAsync(stream);

                traktStatisticss.Should().NotBeNull();
                ITraktStatistics[] statistics = traktStatisticss.ToArray();

                statistics[0].Should().NotBeNull();
                statistics[0].Watchers.Should().Be(129920);
                statistics[0].Plays.Should().Be(3563853);
                statistics[0].Collectors.Should().Be(49711);
                statistics[0].CollectedEpisodes.Should().Be(1310350);
                statistics[0].Comments.Should().Be(96);
                statistics[0].Lists.Should().Be(49468);
                statistics[0].Votes.Should().Be(9274);

                statistics[1].Should().NotBeNull();
                statistics[1].Watchers.Should().BeNull();
                statistics[1].Plays.Should().Be(3563853);
                statistics[1].Collectors.Should().Be(49711);
                statistics[1].CollectedEpisodes.Should().Be(1310350);
                statistics[1].Comments.Should().Be(96);
                statistics[1].Lists.Should().Be(49468);
                statistics[1].Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktStatistics>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IList<ITraktStatistics> traktStatisticss = await jsonReader.ReadArrayAsync(stream);

                traktStatisticss.Should().NotBeNull();
                ITraktStatistics[] statistics = traktStatisticss.ToArray();

                statistics[0].Should().NotBeNull();
                statistics[0].Watchers.Should().BeNull();
                statistics[0].Plays.Should().Be(3563853);
                statistics[0].Collectors.Should().Be(49711);
                statistics[0].CollectedEpisodes.Should().Be(1310350);
                statistics[0].Comments.Should().Be(96);
                statistics[0].Lists.Should().Be(49468);
                statistics[0].Votes.Should().Be(9274);

                statistics[1].Should().NotBeNull();
                statistics[1].Watchers.Should().Be(129920);
                statistics[1].Plays.Should().Be(3563853);
                statistics[1].Collectors.Should().Be(49711);
                statistics[1].CollectedEpisodes.Should().Be(1310350);
                statistics[1].Comments.Should().Be(96);
                statistics[1].Lists.Should().Be(49468);
                statistics[1].Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktStatistics>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IList<ITraktStatistics> traktStatisticss = await jsonReader.ReadArrayAsync(stream);

                traktStatisticss.Should().NotBeNull();
                ITraktStatistics[] statistics = traktStatisticss.ToArray();

                statistics[0].Should().NotBeNull();
                statistics[0].Watchers.Should().BeNull();
                statistics[0].Plays.Should().Be(3563853);
                statistics[0].Collectors.Should().Be(49711);
                statistics[0].CollectedEpisodes.Should().Be(1310350);
                statistics[0].Comments.Should().Be(96);
                statistics[0].Lists.Should().Be(49468);
                statistics[0].Votes.Should().Be(9274);

                statistics[1].Should().NotBeNull();
                statistics[1].Watchers.Should().Be(129920);
                statistics[1].Plays.Should().Be(3563853);
                statistics[1].Collectors.Should().Be(49711);
                statistics[1].CollectedEpisodes.Should().Be(1310350);
                statistics[1].Comments.Should().Be(96);
                statistics[1].Lists.Should().Be(49468);
                statistics[1].Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktStatistics>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IList<ITraktStatistics> traktStatisticss = await jsonReader.ReadArrayAsync(stream);

                traktStatisticss.Should().NotBeNull();
                ITraktStatistics[] statistics = traktStatisticss.ToArray();

                statistics[0].Should().NotBeNull();
                statistics[0].Watchers.Should().Be(129920);
                statistics[0].Plays.Should().Be(3563853);
                statistics[0].Collectors.Should().Be(49711);
                statistics[0].CollectedEpisodes.Should().Be(1310350);
                statistics[0].Comments.Should().Be(96);
                statistics[0].Lists.Should().Be(49468);
                statistics[0].Votes.Should().Be(9274);

                statistics[1].Should().NotBeNull();
                statistics[1].Watchers.Should().BeNull();
                statistics[1].Plays.Should().Be(3563853);
                statistics[1].Collectors.Should().Be(49711);
                statistics[1].CollectedEpisodes.Should().Be(1310350);
                statistics[1].Comments.Should().Be(96);
                statistics[1].Lists.Should().Be(49468);
                statistics[1].Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktStatistics>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                IList<ITraktStatistics> traktStatisticss = await jsonReader.ReadArrayAsync(stream);

                traktStatisticss.Should().NotBeNull();
                ITraktStatistics[] statistics = traktStatisticss.ToArray();

                statistics[0].Should().NotBeNull();
                statistics[0].Watchers.Should().BeNull();
                statistics[0].Plays.Should().Be(3563853);
                statistics[0].Collectors.Should().Be(49711);
                statistics[0].CollectedEpisodes.Should().Be(1310350);
                statistics[0].Comments.Should().Be(96);
                statistics[0].Lists.Should().Be(49468);
                statistics[0].Votes.Should().Be(9274);

                statistics[1].Should().NotBeNull();
                statistics[1].Watchers.Should().BeNull();
                statistics[1].Plays.Should().Be(3563853);
                statistics[1].Collectors.Should().Be(49711);
                statistics[1].CollectedEpisodes.Should().Be(1310350);
                statistics[1].Comments.Should().Be(96);
                statistics[1].Lists.Should().Be(49468);
                statistics[1].Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktStatistics>();
            Func<Task<IList<ITraktStatistics>>> traktStatisticss = () => jsonReader.ReadArrayAsync(default(Stream));
            await traktStatisticss.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_StatisticsArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktStatistics>();

            using (var stream = string.Empty.ToStream())
            {
                IList<ITraktStatistics> traktStatisticss = await jsonReader.ReadArrayAsync(stream);
                traktStatisticss.Should().BeNull();
            }
        }
    }
}
