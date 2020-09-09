namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Recommendations;
    using TraktNet.Objects.Get.Recommendations.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Recommendations.JsonReader")]
    public partial class RecommendationShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().Be(1);
            traktRecommendationShow.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationShow.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendationShow.Notes.Should().Be("Atmospheric for days.");
            traktRecommendationShow.Show.Should().NotBeNull();
            traktRecommendationShow.Show.Title.Should().Be("The Walking Dead");
            traktRecommendationShow.Show.Year.Should().Be(2010);
            traktRecommendationShow.Show.Ids.Should().NotBeNull();
            traktRecommendationShow.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendationShow.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendationShow.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendationShow.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendationShow.Show.Ids.Tmdb.Should().Be(1402U);
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().BeNull();
            traktRecommendationShow.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationShow.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendationShow.Notes.Should().Be("Atmospheric for days.");
            traktRecommendationShow.Show.Should().NotBeNull();
            traktRecommendationShow.Show.Title.Should().Be("The Walking Dead");
            traktRecommendationShow.Show.Year.Should().Be(2010);
            traktRecommendationShow.Show.Ids.Should().NotBeNull();
            traktRecommendationShow.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendationShow.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendationShow.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendationShow.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendationShow.Show.Ids.Tmdb.Should().Be(1402U);
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().Be(1);
            traktRecommendationShow.ListedAt.Should().BeNull();
            traktRecommendationShow.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendationShow.Notes.Should().Be("Atmospheric for days.");
            traktRecommendationShow.Show.Should().NotBeNull();
            traktRecommendationShow.Show.Title.Should().Be("The Walking Dead");
            traktRecommendationShow.Show.Year.Should().Be(2010);
            traktRecommendationShow.Show.Ids.Should().NotBeNull();
            traktRecommendationShow.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendationShow.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendationShow.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendationShow.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendationShow.Show.Ids.Tmdb.Should().Be(1402U);
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().Be(1);
            traktRecommendationShow.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationShow.Type.Should().BeNull();
            traktRecommendationShow.Notes.Should().Be("Atmospheric for days.");
            traktRecommendationShow.Show.Should().NotBeNull();
            traktRecommendationShow.Show.Title.Should().Be("The Walking Dead");
            traktRecommendationShow.Show.Year.Should().Be(2010);
            traktRecommendationShow.Show.Ids.Should().NotBeNull();
            traktRecommendationShow.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendationShow.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendationShow.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendationShow.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendationShow.Show.Ids.Tmdb.Should().Be(1402U);
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().Be(1);
            traktRecommendationShow.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationShow.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendationShow.Notes.Should().BeNull();
            traktRecommendationShow.Show.Should().NotBeNull();
            traktRecommendationShow.Show.Title.Should().Be("The Walking Dead");
            traktRecommendationShow.Show.Year.Should().Be(2010);
            traktRecommendationShow.Show.Ids.Should().NotBeNull();
            traktRecommendationShow.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendationShow.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendationShow.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendationShow.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendationShow.Show.Ids.Tmdb.Should().Be(1402U);
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().Be(1);
            traktRecommendationShow.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationShow.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendationShow.Notes.Should().Be("Atmospheric for days.");
            traktRecommendationShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_6);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().Be(1);
            traktRecommendationShow.ListedAt.Should().BeNull();
            traktRecommendationShow.Type.Should().BeNull();
            traktRecommendationShow.Notes.Should().BeNull();
            traktRecommendationShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_7);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().BeNull();
            traktRecommendationShow.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationShow.Type.Should().BeNull();
            traktRecommendationShow.Notes.Should().BeNull();
            traktRecommendationShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_8);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().BeNull();
            traktRecommendationShow.ListedAt.Should().BeNull();
            traktRecommendationShow.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendationShow.Notes.Should().BeNull();
            traktRecommendationShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_9);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().BeNull();
            traktRecommendationShow.ListedAt.Should().BeNull();
            traktRecommendationShow.Type.Should().BeNull();
            traktRecommendationShow.Notes.Should().Be("Atmospheric for days.");
            traktRecommendationShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_10);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().BeNull();
            traktRecommendationShow.ListedAt.Should().BeNull();
            traktRecommendationShow.Type.Should().BeNull();
            traktRecommendationShow.Notes.Should().BeNull();
            traktRecommendationShow.Show.Should().NotBeNull();
            traktRecommendationShow.Show.Title.Should().Be("The Walking Dead");
            traktRecommendationShow.Show.Year.Should().Be(2010);
            traktRecommendationShow.Show.Ids.Should().NotBeNull();
            traktRecommendationShow.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendationShow.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendationShow.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendationShow.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendationShow.Show.Ids.Tmdb.Should().Be(1402U);
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().BeNull();
            traktRecommendationShow.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationShow.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendationShow.Notes.Should().Be("Atmospheric for days.");
            traktRecommendationShow.Show.Should().NotBeNull();
            traktRecommendationShow.Show.Title.Should().Be("The Walking Dead");
            traktRecommendationShow.Show.Year.Should().Be(2010);
            traktRecommendationShow.Show.Ids.Should().NotBeNull();
            traktRecommendationShow.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendationShow.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendationShow.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendationShow.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendationShow.Show.Ids.Tmdb.Should().Be(1402U);
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().Be(1);
            traktRecommendationShow.ListedAt.Should().BeNull();
            traktRecommendationShow.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendationShow.Notes.Should().Be("Atmospheric for days.");
            traktRecommendationShow.Show.Should().NotBeNull();
            traktRecommendationShow.Show.Title.Should().Be("The Walking Dead");
            traktRecommendationShow.Show.Year.Should().Be(2010);
            traktRecommendationShow.Show.Ids.Should().NotBeNull();
            traktRecommendationShow.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendationShow.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendationShow.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendationShow.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendationShow.Show.Ids.Tmdb.Should().Be(1402U);
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().Be(1);
            traktRecommendationShow.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationShow.Type.Should().BeNull();
            traktRecommendationShow.Notes.Should().Be("Atmospheric for days.");
            traktRecommendationShow.Show.Should().NotBeNull();
            traktRecommendationShow.Show.Title.Should().Be("The Walking Dead");
            traktRecommendationShow.Show.Year.Should().Be(2010);
            traktRecommendationShow.Show.Ids.Should().NotBeNull();
            traktRecommendationShow.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendationShow.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendationShow.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendationShow.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendationShow.Show.Ids.Tmdb.Should().Be(1402U);
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().Be(1);
            traktRecommendationShow.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationShow.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendationShow.Notes.Should().BeNull();
            traktRecommendationShow.Show.Should().NotBeNull();
            traktRecommendationShow.Show.Title.Should().Be("The Walking Dead");
            traktRecommendationShow.Show.Year.Should().Be(2010);
            traktRecommendationShow.Show.Ids.Should().NotBeNull();
            traktRecommendationShow.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendationShow.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendationShow.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendationShow.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendationShow.Show.Ids.Tmdb.Should().Be(1402U);
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().Be(1);
            traktRecommendationShow.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationShow.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendationShow.Notes.Should().Be("Atmospheric for days.");
            traktRecommendationShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_6);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().BeNull();
            traktRecommendationShow.ListedAt.Should().BeNull();
            traktRecommendationShow.Type.Should().BeNull();
            traktRecommendationShow.Notes.Should().BeNull();
            traktRecommendationShow.Show.Should().BeNull();
        }

        [Fact]
        public void Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();
            Func<Task<ITraktRecommendationShow>> traktRecommendationShow = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktRecommendationShow.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new RecommendationShowObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationShow traktRecommendationShow = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktRecommendationShow.Should().BeNull();
        }
    }
}
