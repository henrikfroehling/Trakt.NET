﻿namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class StatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_13()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_13.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_14()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_14.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_8()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_8.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            var traktStatistics = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_StatisticsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new StatisticsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktStatistics = await traktJsonReader.ReadObjectAsync(stream);
                traktStatistics.Should().BeNull();
            }
        }
    }
}
