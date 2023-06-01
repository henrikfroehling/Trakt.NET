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
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_MOVIE_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Id.Should().Be(101);
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
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_MOVIE_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Id.Should().BeNull();
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
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_MOVIE_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Id.Should().Be(101);
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
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_MOVIE_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Id.Should().Be(101);
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
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_MOVIE_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Id.Should().Be(101);
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
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_MOVIE_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Id.Should().Be(101);
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
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_MOVIE_INCOMPLETE_6);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Id.Should().Be(101);
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendation.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendation.Movie.Should().BeNull();
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_MOVIE_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Id.Should().BeNull();
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
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_MOVIE_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Id.Should().Be(101);
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
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_MOVIE_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Id.Should().Be(101);
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
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_MOVIE_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Id.Should().Be(101);
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
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_MOVIE_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Id.Should().Be(101);
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
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_MOVIE_NOT_VALID_6);
            using var jsonReader = new JsonTextReader(reader);
     
            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Id.Should().Be(101);
            traktRecommendation.Rank.Should().Be(1);
            traktRecommendation.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendation.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendation.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendation.Movie.Should().BeNull();
            traktRecommendation.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new RecommendationObjectJsonReader();

            using var reader = new StringReader(JSON_MOVIE_NOT_VALID_7);
            using var jsonReader = new JsonTextReader(reader);
     
            ITraktRecommendation traktRecommendation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendation.Should().NotBeNull();
            traktRecommendation.Id.Should().BeNull();
            traktRecommendation.Rank.Should().BeNull();
            traktRecommendation.ListedAt.Should().BeNull();
            traktRecommendation.Type.Should().BeNull();
            traktRecommendation.Notes.Should().BeNull();
            traktRecommendation.Movie.Should().BeNull();
            traktRecommendation.Show.Should().BeNull();
        }
    }
}
