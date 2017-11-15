namespace TraktApiSharp.Tests.Objects.Post.Responses.Json
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Responses.Json;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundSeasonArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new PostResponseNotFoundSeasonArrayJsonReader();

            var notFoundSeasons = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            notFoundSeasons.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new PostResponseNotFoundSeasonArrayJsonReader();

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
            var jsonReader = new PostResponseNotFoundSeasonArrayJsonReader();

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
            var jsonReader = new PostResponseNotFoundSeasonArrayJsonReader();

            var notFoundSeasons = await jsonReader.ReadArrayAsync(default(string));
            notFoundSeasons.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new PostResponseNotFoundSeasonArrayJsonReader();

            var notFoundSeasons = await jsonReader.ReadArrayAsync(string.Empty);
            notFoundSeasons.Should().BeNull();
        }
    }
}
