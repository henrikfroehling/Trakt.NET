﻿namespace TraktNet.Objects.Get.Tests.Seasons.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Seasons.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class SeasonIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SeasonIdsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new SeasonIdsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktSeasonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(61430);
                traktSeasonIds.Tvdb.Should().Be(279121U);
                traktSeasonIds.Tmdb.Should().Be(60523U);
                traktSeasonIds.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new SeasonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktSeasonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(0);
                traktSeasonIds.Tvdb.Should().Be(279121U);
                traktSeasonIds.Tmdb.Should().Be(60523U);
                traktSeasonIds.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new SeasonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktSeasonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(61430);
                traktSeasonIds.Tvdb.Should().BeNull();
                traktSeasonIds.Tmdb.Should().Be(60523U);
                traktSeasonIds.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new SeasonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktSeasonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(61430);
                traktSeasonIds.Tvdb.Should().Be(279121U);
                traktSeasonIds.Tmdb.Should().BeNull();
                traktSeasonIds.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new SeasonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktSeasonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(61430);
                traktSeasonIds.Tvdb.Should().Be(279121U);
                traktSeasonIds.Tmdb.Should().Be(60523U);
                traktSeasonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new SeasonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktSeasonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(61430);
                traktSeasonIds.Tvdb.Should().BeNull();
                traktSeasonIds.Tmdb.Should().BeNull();
                traktSeasonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new SeasonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktSeasonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(0);
                traktSeasonIds.Tvdb.Should().Be(279121U);
                traktSeasonIds.Tmdb.Should().BeNull();
                traktSeasonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var traktJsonReader = new SeasonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktSeasonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(0);
                traktSeasonIds.Tvdb.Should().BeNull();
                traktSeasonIds.Tmdb.Should().Be(60523U);
                traktSeasonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var traktJsonReader = new SeasonIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktSeasonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(0);
                traktSeasonIds.Tvdb.Should().BeNull();
                traktSeasonIds.Tmdb.Should().BeNull();
                traktSeasonIds.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new SeasonIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktSeasonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(0);
                traktSeasonIds.Tvdb.Should().Be(279121U);
                traktSeasonIds.Tmdb.Should().Be(60523U);
                traktSeasonIds.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new SeasonIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktSeasonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(61430);
                traktSeasonIds.Tvdb.Should().BeNull();
                traktSeasonIds.Tmdb.Should().Be(60523U);
                traktSeasonIds.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new SeasonIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktSeasonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(61430);
                traktSeasonIds.Tvdb.Should().Be(279121U);
                traktSeasonIds.Tmdb.Should().BeNull();
                traktSeasonIds.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new SeasonIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktSeasonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(61430);
                traktSeasonIds.Tvdb.Should().Be(279121U);
                traktSeasonIds.Tmdb.Should().Be(60523U);
                traktSeasonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var traktJsonReader = new SeasonIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktSeasonIds = await traktJsonReader.ReadObjectAsync(stream);

                traktSeasonIds.Should().NotBeNull();
                traktSeasonIds.Trakt.Should().Be(0);
                traktSeasonIds.Tvdb.Should().BeNull();
                traktSeasonIds.Tmdb.Should().BeNull();
                traktSeasonIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new SeasonIdsObjectJsonReader();
            Func<Task<ITraktSeasonIds>> traktSeasonIds = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await traktSeasonIds.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonIdsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new SeasonIdsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktSeasonIds = await traktJsonReader.ReadObjectAsync(stream);
                traktSeasonIds.Should().BeNull();
            }
        }
    }
}
