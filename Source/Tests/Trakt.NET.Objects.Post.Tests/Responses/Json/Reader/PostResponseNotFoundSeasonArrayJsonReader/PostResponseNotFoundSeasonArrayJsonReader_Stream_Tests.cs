﻿namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Responses;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundSeasonArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var notFoundSeasons = await jsonReader.ReadArrayAsync(stream);
                notFoundSeasons.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var notFoundSeasons = await jsonReader.ReadArrayAsync(stream);
                notFoundSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var notFoundSeason = notFoundSeasons.ToArray();

                notFoundSeason[0].Should().NotBeNull();
                notFoundSeason[0].Ids.Should().NotBeNull();
                notFoundSeason[0].Ids.Trakt.Should().Be(61430U);
                notFoundSeason[0].Ids.Tvdb.Should().Be(279121U);
                notFoundSeason[0].Ids.Tmdb.Should().Be(60523U);
                notFoundSeason[0].Ids.TvRage.Should().Be(36939U);

                notFoundSeason[1].Should().NotBeNull();
                notFoundSeason[1].Ids.Should().NotBeNull();
                notFoundSeason[1].Ids.Trakt.Should().Be(61431U);
                notFoundSeason[1].Ids.Tvdb.Should().Be(578373U);
                notFoundSeason[1].Ids.Tmdb.Should().Be(60524U);
                notFoundSeason[1].Ids.TvRage.Should().Be(36940U);
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_Stream_Not_Valid()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var notFoundSeasons = await jsonReader.ReadArrayAsync(stream);
                notFoundSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var notFoundSeason = notFoundSeasons.ToArray();

                notFoundSeason[0].Should().NotBeNull();
                notFoundSeason[0].Ids.Should().NotBeNull();
                notFoundSeason[0].Ids.Trakt.Should().Be(61430U);
                notFoundSeason[0].Ids.Tvdb.Should().Be(279121U);
                notFoundSeason[0].Ids.Tmdb.Should().Be(60523U);
                notFoundSeason[0].Ids.TvRage.Should().Be(36939U);

                notFoundSeason[1].Should().NotBeNull();
                notFoundSeason[1].Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();
            Func<Task<IEnumerable<ITraktPostResponseNotFoundSeason>>> notFoundSeasons = () => jsonReader.ReadArrayAsync(default(Stream));
            await notFoundSeasons.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();

            using (var stream = string.Empty.ToStream())
            {
                var notFoundSeasons = await jsonReader.ReadArrayAsync(stream);
                notFoundSeasons.Should().BeNull();
            }
        }
    }
}
