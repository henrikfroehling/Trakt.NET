namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System;
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
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_COMPLETE);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendation.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendation.Movie.Should().NotBeNull();
            traktRecommendation.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendation.Movie.Year.Should().Be(2010);
            traktRecommendation.Movie.Ids.Should().NotBeNull();
            traktRecommendation.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendation.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendation.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendation.Movie.Ids.Tmdb.Should().Be(20526U);
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_INCOMPLETE_1);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().BeNull();
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendation.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendation.Movie.Should().NotBeNull();
            traktRecommendation.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendation.Movie.Year.Should().Be(2010);
            traktRecommendation.Movie.Ids.Should().NotBeNull();
            traktRecommendation.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendation.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendation.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendation.Movie.Ids.Tmdb.Should().Be(20526U);
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_INCOMPLETE_2);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().BeNull();
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendation.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendation.Movie.Should().NotBeNull();
            traktRecommendation.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendation.Movie.Year.Should().Be(2010);
            traktRecommendation.Movie.Ids.Should().NotBeNull();
            traktRecommendation.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendation.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendation.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendation.Movie.Ids.Tmdb.Should().Be(20526U);
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_INCOMPLETE_3);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().BeNull();
            traktRecommendation.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendation.Movie.Should().NotBeNull();
            traktRecommendation.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendation.Movie.Year.Should().Be(2010);
            traktRecommendation.Movie.Ids.Should().NotBeNull();
            traktRecommendation.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendation.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendation.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendation.Movie.Ids.Tmdb.Should().Be(20526U);
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_INCOMPLETE_4);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendation.Notes.Should().BeNull();
            traktRecommendation.Movie.Should().NotBeNull();
            traktRecommendation.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendation.Movie.Year.Should().Be(2010);
            traktRecommendation.Movie.Ids.Should().NotBeNull();
            traktRecommendation.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendation.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendation.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendation.Movie.Ids.Tmdb.Should().Be(20526U);
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_INCOMPLETE_5);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendation.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendation.Movie.Should().BeNull();
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_INCOMPLETE_6);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().BeNull();
            traktRecommendation.Type.Should().BeNull();
            traktRecommendation.Notes.Should().BeNull();
            traktRecommendation.Movie.Should().BeNull();
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_INCOMPLETE_7);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().BeNull();
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().BeNull();
            traktRecommendation.Notes.Should().BeNull();
            traktRecommendation.Movie.Should().BeNull();
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_INCOMPLETE_8);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().BeNull();
            traktRecommendation.ListedAt.Should().BeNull();
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendation.Notes.Should().BeNull();
            traktRecommendation.Movie.Should().BeNull();
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_INCOMPLETE_9);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().BeNull();
            traktRecommendation.ListedAt.Should().BeNull();
            traktRecommendation.Type.Should().BeNull();
            traktRecommendation.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendation.Movie.Should().BeNull();
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_INCOMPLETE_10);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().BeNull();
            traktRecommendation.ListedAt.Should().BeNull();
            traktRecommendation.Type.Should().BeNull();
            traktRecommendation.Notes.Should().BeNull();
            traktRecommendation.Movie.Should().NotBeNull();
            traktRecommendation.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendation.Movie.Year.Should().Be(2010);
            traktRecommendation.Movie.Ids.Should().NotBeNull();
            traktRecommendation.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendation.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendation.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendation.Movie.Ids.Tmdb.Should().Be(20526U);
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_NOT_VALID_1);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().BeNull();
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendation.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendation.Movie.Should().NotBeNull();
            traktRecommendation.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendation.Movie.Year.Should().Be(2010);
            traktRecommendation.Movie.Ids.Should().NotBeNull();
            traktRecommendation.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendation.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendation.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendation.Movie.Ids.Tmdb.Should().Be(20526U);
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_NOT_VALID_2);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().BeNull();
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendation.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendation.Movie.Should().NotBeNull();
            traktRecommendation.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendation.Movie.Year.Should().Be(2010);
            traktRecommendation.Movie.Ids.Should().NotBeNull();
            traktRecommendation.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendation.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendation.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendation.Movie.Ids.Tmdb.Should().Be(20526U);
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_NOT_VALID_3);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().BeNull();
            traktRecommendation.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendation.Movie.Should().NotBeNull();
            traktRecommendation.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendation.Movie.Year.Should().Be(2010);
            traktRecommendation.Movie.Ids.Should().NotBeNull();
            traktRecommendation.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendation.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendation.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendation.Movie.Ids.Tmdb.Should().Be(20526U);
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_NOT_VALID_4);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendation.Notes.Should().BeNull();
            traktRecommendation.Movie.Should().NotBeNull();
            traktRecommendation.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendation.Movie.Year.Should().Be(2010);
            traktRecommendation.Movie.Ids.Should().NotBeNull();
            traktRecommendation.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendation.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendation.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendation.Movie.Ids.Tmdb.Should().Be(20526U);
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_NOT_VALID_5);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendation.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendation.Movie.Should().BeNull();
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new RecommendationObjectJsonReader();

            ITraktRecommendation traktRecommendation = await jsonReader.ReadObjectAsync(JSON_MOVIE_NOT_VALID_6);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Rank.Should().BeNull();
            traktRecommendation.ListedAt.Should().BeNull();
            traktRecommendation.Type.Should().BeNull();
            traktRecommendation.Notes.Should().BeNull();
            traktRecommendation.Movie.Should().BeNull();
            traktRecommendation.Show.Should().BeNull();
        }
    }
}
