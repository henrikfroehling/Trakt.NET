namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundSeasonArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new PostResponseNotFoundSeasonArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundSeasons = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundSeasons.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new PostResponseNotFoundSeasonArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundSeasons = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new PostResponseNotFoundSeasonArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundSeasons = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new PostResponseNotFoundSeasonArrayJsonReader();

            var notFoundSeasons = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            notFoundSeasons.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new PostResponseNotFoundSeasonArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundSeasons = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundSeasons.Should().BeNull();
            }
        }
    }
}
