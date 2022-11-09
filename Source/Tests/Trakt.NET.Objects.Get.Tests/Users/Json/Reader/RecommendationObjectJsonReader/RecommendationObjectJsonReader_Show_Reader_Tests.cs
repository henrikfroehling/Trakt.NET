namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonReader")]
    public partial class RecommendationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendation.Notes.Should().Be("Atmospheric for days.");
            traktRecommendation.Show.Should().NotBeNull();
            traktRecommendation.Show.Title.Should().Be("The Walking Dead");
            traktRecommendation.Show.Year.Should().Be(2010);
            traktRecommendation.Show.Ids.Should().NotBeNull();
            traktRecommendation.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendation.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendation.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendation.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendation.Show.Ids.Tmdb.Should().Be(1402U);
            traktRecommendation.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().BeNull();
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendation.Notes.Should().Be("Atmospheric for days.");
            traktRecommendation.Show.Should().NotBeNull();
            traktRecommendation.Show.Title.Should().Be("The Walking Dead");
            traktRecommendation.Show.Year.Should().Be(2010);
            traktRecommendation.Show.Ids.Should().NotBeNull();
            traktRecommendation.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendation.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendation.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendation.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendation.Show.Ids.Tmdb.Should().Be(1402U);
            traktRecommendation.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().BeNull();
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendation.Notes.Should().Be("Atmospheric for days.");
            traktRecommendation.Show.Should().NotBeNull();
            traktRecommendation.Show.Title.Should().Be("The Walking Dead");
            traktRecommendation.Show.Year.Should().Be(2010);
            traktRecommendation.Show.Ids.Should().NotBeNull();
            traktRecommendation.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendation.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendation.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendation.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendation.Show.Ids.Tmdb.Should().Be(1402U);
            traktRecommendation.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().BeNull();
            traktRecommendation.Notes.Should().Be("Atmospheric for days.");
            traktRecommendation.Show.Should().NotBeNull();
            traktRecommendation.Show.Title.Should().Be("The Walking Dead");
            traktRecommendation.Show.Year.Should().Be(2010);
            traktRecommendation.Show.Ids.Should().NotBeNull();
            traktRecommendation.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendation.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendation.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendation.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendation.Show.Ids.Tmdb.Should().Be(1402U);
            traktRecommendation.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendation.Notes.Should().BeNull();
            traktRecommendation.Show.Should().NotBeNull();
            traktRecommendation.Show.Title.Should().Be("The Walking Dead");
            traktRecommendation.Show.Year.Should().Be(2010);
            traktRecommendation.Show.Ids.Should().NotBeNull();
            traktRecommendation.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendation.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendation.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendation.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendation.Show.Ids.Tmdb.Should().Be(1402U);
            traktRecommendation.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendation.Notes.Should().Be("Atmospheric for days.");
            traktRecommendation.Show.Should().BeNull();
            traktRecommendation.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_INCOMPLETE_6);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().BeNull();
            traktRecommendation.Type.Should().BeNull();
            traktRecommendation.Notes.Should().BeNull();
            traktRecommendation.Show.Should().BeNull();
            traktRecommendation.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_INCOMPLETE_7);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().BeNull();
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().BeNull();
            traktRecommendation.Notes.Should().BeNull();
            traktRecommendation.Show.Should().BeNull();
            traktRecommendation.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_INCOMPLETE_8);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().BeNull();
            traktRecommendation.ListedAt.Should().BeNull();
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendation.Notes.Should().BeNull();
            traktRecommendation.Show.Should().BeNull();
            traktRecommendation.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_INCOMPLETE_9);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().BeNull();
            traktRecommendation.ListedAt.Should().BeNull();
            traktRecommendation.Type.Should().BeNull();
            traktRecommendation.Notes.Should().Be("Atmospheric for days.");
            traktRecommendation.Show.Should().BeNull();
            traktRecommendation.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_INCOMPLETE_10);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().BeNull();
            traktRecommendation.ListedAt.Should().BeNull();
            traktRecommendation.Type.Should().BeNull();
            traktRecommendation.Notes.Should().BeNull();
            traktRecommendation.Show.Should().NotBeNull();
            traktRecommendation.Show.Title.Should().Be("The Walking Dead");
            traktRecommendation.Show.Year.Should().Be(2010);
            traktRecommendation.Show.Ids.Should().NotBeNull();
            traktRecommendation.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendation.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendation.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendation.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendation.Show.Ids.Tmdb.Should().Be(1402U);
            traktRecommendation.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().BeNull();
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendation.Notes.Should().Be("Atmospheric for days.");
            traktRecommendation.Show.Should().NotBeNull();
            traktRecommendation.Show.Title.Should().Be("The Walking Dead");
            traktRecommendation.Show.Year.Should().Be(2010);
            traktRecommendation.Show.Ids.Should().NotBeNull();
            traktRecommendation.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendation.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendation.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendation.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendation.Show.Ids.Tmdb.Should().Be(1402U);
            traktRecommendation.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().BeNull();
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendation.Notes.Should().Be("Atmospheric for days.");
            traktRecommendation.Show.Should().NotBeNull();
            traktRecommendation.Show.Title.Should().Be("The Walking Dead");
            traktRecommendation.Show.Year.Should().Be(2010);
            traktRecommendation.Show.Ids.Should().NotBeNull();
            traktRecommendation.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendation.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendation.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendation.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendation.Show.Ids.Tmdb.Should().Be(1402U);
            traktRecommendation.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().BeNull();
            traktRecommendation.Notes.Should().Be("Atmospheric for days.");
            traktRecommendation.Show.Should().NotBeNull();
            traktRecommendation.Show.Title.Should().Be("The Walking Dead");
            traktRecommendation.Show.Year.Should().Be(2010);
            traktRecommendation.Show.Ids.Should().NotBeNull();
            traktRecommendation.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendation.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendation.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendation.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendation.Show.Ids.Tmdb.Should().Be(1402U);
            traktRecommendation.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendation.Notes.Should().BeNull();
            traktRecommendation.Show.Should().NotBeNull();
            traktRecommendation.Show.Title.Should().Be("The Walking Dead");
            traktRecommendation.Show.Year.Should().Be(2010);
            traktRecommendation.Show.Ids.Should().NotBeNull();
            traktRecommendation.Show.Ids.Trakt.Should().Be(2U);
            traktRecommendation.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktRecommendation.Show.Ids.Tvdb.Should().Be(153021U);
            traktRecommendation.Show.Ids.Imdb.Should().Be("tt1520211");
            traktRecommendation.Show.Ids.Tmdb.Should().Be(1402U);
            traktRecommendation.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendation.Notes.Should().Be("Atmospheric for days.");
            traktRecommendation.Show.Should().BeNull();
            traktRecommendation.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_NOT_VALID_6);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().BeNull();
            traktRecommendation.ListedAt.Should().BeNull();
            traktRecommendation.Type.Should().BeNull();
            traktRecommendation.Notes.Should().BeNull();
            traktRecommendation.Show.Should().BeNull();
            traktRecommendation.Movie.Should().BeNull();
        }
    }
}
