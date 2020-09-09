namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Recommendations;
    using TraktNet.Objects.Get.Recommendations.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Recommendations.JsonReader")]
    public partial class RecommendationMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().Be(1);
            traktRecommendationMovie.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationMovie.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendationMovie.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendationMovie.Movie.Should().NotBeNull();
            traktRecommendationMovie.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendationMovie.Movie.Year.Should().Be(2010);
            traktRecommendationMovie.Movie.Ids.Should().NotBeNull();
            traktRecommendationMovie.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendationMovie.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendationMovie.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendationMovie.Movie.Ids.Tmdb.Should().Be(20526U);
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().BeNull();
            traktRecommendationMovie.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationMovie.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendationMovie.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendationMovie.Movie.Should().NotBeNull();
            traktRecommendationMovie.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendationMovie.Movie.Year.Should().Be(2010);
            traktRecommendationMovie.Movie.Ids.Should().NotBeNull();
            traktRecommendationMovie.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendationMovie.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendationMovie.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendationMovie.Movie.Ids.Tmdb.Should().Be(20526U);
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().Be(1);
            traktRecommendationMovie.ListedAt.Should().BeNull();
            traktRecommendationMovie.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendationMovie.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendationMovie.Movie.Should().NotBeNull();
            traktRecommendationMovie.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendationMovie.Movie.Year.Should().Be(2010);
            traktRecommendationMovie.Movie.Ids.Should().NotBeNull();
            traktRecommendationMovie.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendationMovie.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendationMovie.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendationMovie.Movie.Ids.Tmdb.Should().Be(20526U);
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().Be(1);
            traktRecommendationMovie.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationMovie.Type.Should().BeNull();
            traktRecommendationMovie.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendationMovie.Movie.Should().NotBeNull();
            traktRecommendationMovie.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendationMovie.Movie.Year.Should().Be(2010);
            traktRecommendationMovie.Movie.Ids.Should().NotBeNull();
            traktRecommendationMovie.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendationMovie.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendationMovie.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendationMovie.Movie.Ids.Tmdb.Should().Be(20526U);
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().Be(1);
            traktRecommendationMovie.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationMovie.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendationMovie.Notes.Should().BeNull();
            traktRecommendationMovie.Movie.Should().NotBeNull();
            traktRecommendationMovie.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendationMovie.Movie.Year.Should().Be(2010);
            traktRecommendationMovie.Movie.Ids.Should().NotBeNull();
            traktRecommendationMovie.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendationMovie.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendationMovie.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendationMovie.Movie.Ids.Tmdb.Should().Be(20526U);
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().Be(1);
            traktRecommendationMovie.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationMovie.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendationMovie.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendationMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().Be(1);
            traktRecommendationMovie.ListedAt.Should().BeNull();
            traktRecommendationMovie.Type.Should().BeNull();
            traktRecommendationMovie.Notes.Should().BeNull();
            traktRecommendationMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().BeNull();
            traktRecommendationMovie.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationMovie.Type.Should().BeNull();
            traktRecommendationMovie.Notes.Should().BeNull();
            traktRecommendationMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().BeNull();
            traktRecommendationMovie.ListedAt.Should().BeNull();
            traktRecommendationMovie.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendationMovie.Notes.Should().BeNull();
            traktRecommendationMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().BeNull();
            traktRecommendationMovie.ListedAt.Should().BeNull();
            traktRecommendationMovie.Type.Should().BeNull();
            traktRecommendationMovie.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendationMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().BeNull();
            traktRecommendationMovie.ListedAt.Should().BeNull();
            traktRecommendationMovie.Type.Should().BeNull();
            traktRecommendationMovie.Notes.Should().BeNull();
            traktRecommendationMovie.Movie.Should().NotBeNull();
            traktRecommendationMovie.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendationMovie.Movie.Year.Should().Be(2010);
            traktRecommendationMovie.Movie.Ids.Should().NotBeNull();
            traktRecommendationMovie.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendationMovie.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendationMovie.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendationMovie.Movie.Ids.Tmdb.Should().Be(20526U);
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().BeNull();
            traktRecommendationMovie.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationMovie.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendationMovie.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendationMovie.Movie.Should().NotBeNull();
            traktRecommendationMovie.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendationMovie.Movie.Year.Should().Be(2010);
            traktRecommendationMovie.Movie.Ids.Should().NotBeNull();
            traktRecommendationMovie.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendationMovie.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendationMovie.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendationMovie.Movie.Ids.Tmdb.Should().Be(20526U);
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().Be(1);
            traktRecommendationMovie.ListedAt.Should().BeNull();
            traktRecommendationMovie.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendationMovie.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendationMovie.Movie.Should().NotBeNull();
            traktRecommendationMovie.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendationMovie.Movie.Year.Should().Be(2010);
            traktRecommendationMovie.Movie.Ids.Should().NotBeNull();
            traktRecommendationMovie.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendationMovie.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendationMovie.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendationMovie.Movie.Ids.Tmdb.Should().Be(20526U);
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().Be(1);
            traktRecommendationMovie.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationMovie.Type.Should().BeNull();
            traktRecommendationMovie.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendationMovie.Movie.Should().NotBeNull();
            traktRecommendationMovie.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendationMovie.Movie.Year.Should().Be(2010);
            traktRecommendationMovie.Movie.Ids.Should().NotBeNull();
            traktRecommendationMovie.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendationMovie.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendationMovie.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendationMovie.Movie.Ids.Tmdb.Should().Be(20526U);
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().Be(1);
            traktRecommendationMovie.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationMovie.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendationMovie.Notes.Should().BeNull();
            traktRecommendationMovie.Movie.Should().NotBeNull();
            traktRecommendationMovie.Movie.Title.Should().Be("TRON: Legacy");
            traktRecommendationMovie.Movie.Year.Should().Be(2010);
            traktRecommendationMovie.Movie.Ids.Should().NotBeNull();
            traktRecommendationMovie.Movie.Ids.Trakt.Should().Be(1U);
            traktRecommendationMovie.Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            traktRecommendationMovie.Movie.Ids.Imdb.Should().Be("tt1104001");
            traktRecommendationMovie.Movie.Ids.Tmdb.Should().Be(20526U);
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().Be(1);
            traktRecommendationMovie.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationMovie.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendationMovie.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendationMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();

            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().BeNull();
            traktRecommendationMovie.ListedAt.Should().BeNull();
            traktRecommendationMovie.Type.Should().BeNull();
            traktRecommendationMovie.Notes.Should().BeNull();
            traktRecommendationMovie.Movie.Should().BeNull();
        }

        [Fact]
        public void Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();
            Func<Task<ITraktRecommendationMovie>> traktRecommendationMovie = () => jsonReader.ReadObjectAsync(default(string));
            traktRecommendationMovie.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new RecommendationMovieObjectJsonReader();
            ITraktRecommendationMovie traktRecommendationMovie = await jsonReader.ReadObjectAsync(string.Empty);
            traktRecommendationMovie.Should().BeNull();
        }
    }
}
