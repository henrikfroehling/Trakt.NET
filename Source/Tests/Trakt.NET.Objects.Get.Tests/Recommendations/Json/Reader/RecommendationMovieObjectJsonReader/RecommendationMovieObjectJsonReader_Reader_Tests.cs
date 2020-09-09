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
    public partial class RecommendationMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().Be(1);
            traktRecommendationMovie.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationMovie.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendationMovie.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendationMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_6);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().Be(1);
            traktRecommendationMovie.ListedAt.Should().BeNull();
            traktRecommendationMovie.Type.Should().BeNull();
            traktRecommendationMovie.Notes.Should().BeNull();
            traktRecommendationMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_7);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().BeNull();
            traktRecommendationMovie.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationMovie.Type.Should().BeNull();
            traktRecommendationMovie.Notes.Should().BeNull();
            traktRecommendationMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_8);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().BeNull();
            traktRecommendationMovie.ListedAt.Should().BeNull();
            traktRecommendationMovie.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendationMovie.Notes.Should().BeNull();
            traktRecommendationMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_9);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().BeNull();
            traktRecommendationMovie.ListedAt.Should().BeNull();
            traktRecommendationMovie.Type.Should().BeNull();
            traktRecommendationMovie.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendationMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_10);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().Be(1);
            traktRecommendationMovie.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationMovie.Type.Should().Be(TraktRecommendationObjectType.Movie);
            traktRecommendationMovie.Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            traktRecommendationMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_6);
            using var jsonReader = new JsonTextReader(reader);
     
            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendationMovie.Should().NotBeNull();
            traktRecommendationMovie.Rank.Should().BeNull();
            traktRecommendationMovie.ListedAt.Should().BeNull();
            traktRecommendationMovie.Type.Should().BeNull();
            traktRecommendationMovie.Notes.Should().BeNull();
            traktRecommendationMovie.Movie.Should().BeNull();
        }

        [Fact]
        public void Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();
            Func<Task<ITraktRecommendationMovie>> traktRecommendationMovie = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktRecommendationMovie.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new RecommendationMovieObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            ITraktRecommendationMovie traktRecommendationMovie = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktRecommendationMovie.Should().BeNull();
        }
    }
}
