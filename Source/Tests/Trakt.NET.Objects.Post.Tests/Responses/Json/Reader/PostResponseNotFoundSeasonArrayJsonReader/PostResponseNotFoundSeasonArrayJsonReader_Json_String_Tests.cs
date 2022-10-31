namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Responses;
    using Xunit;

    [TestCategory("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundSeasonArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();

            var notFoundSeasons = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            notFoundSeasons.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();

            var notFoundSeasons = await jsonReader.ReadArrayAsync(JSON_COMPLETE);
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

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_Json_String_Not_Valid()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();

            var notFoundSeasons = await jsonReader.ReadArrayAsync(JSON_NOT_VALID);
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

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();
            Func<Task<IEnumerable<ITraktPostResponseNotFoundSeason>>> notFoundSeasons = () => jsonReader.ReadArrayAsync(default(string));
            await notFoundSeasons.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();

            var notFoundSeasons = await jsonReader.ReadArrayAsync(string.Empty);
            notFoundSeasons.Should().BeNull();
        }
    }
}
