namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Recommendations;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Recommendations.JsonReader")]
    public partial class RecommendationMovieArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecommendationMovieArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationMovie>();

            using var reader = new StringReader(JSON_EMPTY_ARRAY);
            using var jsonReader = new JsonTextReader(reader);

            IEnumerable<ITraktRecommendationMovie> traktRecommendationMovies = await traktJsonReader.ReadArrayAsync(jsonReader);
            traktRecommendationMovies.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_RecommendationMovieArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationMovie>();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            
            IEnumerable<ITraktRecommendationMovie> traktRecommendationMovies = await traktJsonReader.ReadArrayAsync(jsonReader);
            traktRecommendationMovies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendationMovie[] recommendationMovies = traktRecommendationMovies.ToArray();

            recommendationMovies[0].Should().NotBeNull();
            recommendationMovies[0].Rank.Should().Be(1);
            recommendationMovies[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[0].Type.Should().Be(TraktRecommendationObjectType.Movie);
            recommendationMovies[0].Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            recommendationMovies[0].Movie.Should().NotBeNull();
            recommendationMovies[0].Movie.Title.Should().Be("TRON: Legacy");
            recommendationMovies[0].Movie.Year.Should().Be(2010);
            recommendationMovies[0].Movie.Ids.Should().NotBeNull();
            recommendationMovies[0].Movie.Ids.Trakt.Should().Be(1U);
            recommendationMovies[0].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            recommendationMovies[0].Movie.Ids.Imdb.Should().Be("tt1104001");
            recommendationMovies[0].Movie.Ids.Tmdb.Should().Be(20526U);

            recommendationMovies[1].Should().NotBeNull();
            recommendationMovies[1].Rank.Should().Be(1);
            recommendationMovies[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[1].Type.Should().Be(TraktRecommendationObjectType.Movie);
            recommendationMovies[1].Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            recommendationMovies[1].Movie.Should().NotBeNull();
            recommendationMovies[1].Movie.Title.Should().Be("TRON: Legacy");
            recommendationMovies[1].Movie.Year.Should().Be(2010);
            recommendationMovies[1].Movie.Ids.Should().NotBeNull();
            recommendationMovies[1].Movie.Ids.Trakt.Should().Be(1U);
            recommendationMovies[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            recommendationMovies[1].Movie.Ids.Imdb.Should().Be("tt1104001");
            recommendationMovies[1].Movie.Ids.Tmdb.Should().Be(20526U);
        }

        [Fact]
        public async Task Test_RecommendationMovieArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationMovie>();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            
            IEnumerable<ITraktRecommendationMovie> traktRecommendationMovies = await traktJsonReader.ReadArrayAsync(jsonReader);
            traktRecommendationMovies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendationMovie[] recommendationMovies = traktRecommendationMovies.ToArray();

            recommendationMovies[0].Should().NotBeNull();
            recommendationMovies[0].Rank.Should().Be(1);
            recommendationMovies[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[0].Type.Should().Be(TraktRecommendationObjectType.Movie);
            recommendationMovies[0].Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            recommendationMovies[0].Movie.Should().NotBeNull();
            recommendationMovies[0].Movie.Title.Should().Be("TRON: Legacy");
            recommendationMovies[0].Movie.Year.Should().Be(2010);
            recommendationMovies[0].Movie.Ids.Should().NotBeNull();
            recommendationMovies[0].Movie.Ids.Trakt.Should().Be(1U);
            recommendationMovies[0].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            recommendationMovies[0].Movie.Ids.Imdb.Should().Be("tt1104001");
            recommendationMovies[0].Movie.Ids.Tmdb.Should().Be(20526U);

            recommendationMovies[1].Should().NotBeNull();
            recommendationMovies[1].Rank.Should().BeNull();
            recommendationMovies[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[1].Type.Should().Be(TraktRecommendationObjectType.Movie);
            recommendationMovies[1].Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            recommendationMovies[1].Movie.Should().NotBeNull();
            recommendationMovies[1].Movie.Title.Should().Be("TRON: Legacy");
            recommendationMovies[1].Movie.Year.Should().Be(2010);
            recommendationMovies[1].Movie.Ids.Should().NotBeNull();
            recommendationMovies[1].Movie.Ids.Trakt.Should().Be(1U);
            recommendationMovies[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            recommendationMovies[1].Movie.Ids.Imdb.Should().Be("tt1104001");
            recommendationMovies[1].Movie.Ids.Tmdb.Should().Be(20526U);
        }

        [Fact]
        public async Task Test_RecommendationMovieArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationMovie>();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            
            IEnumerable<ITraktRecommendationMovie> traktRecommendationMovies = await traktJsonReader.ReadArrayAsync(jsonReader);
            traktRecommendationMovies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendationMovie[] recommendationMovies = traktRecommendationMovies.ToArray();

            recommendationMovies[0].Should().NotBeNull();
            recommendationMovies[0].Rank.Should().BeNull();
            recommendationMovies[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[0].Type.Should().Be(TraktRecommendationObjectType.Movie);
            recommendationMovies[0].Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            recommendationMovies[0].Movie.Should().NotBeNull();
            recommendationMovies[0].Movie.Title.Should().Be("TRON: Legacy");
            recommendationMovies[0].Movie.Year.Should().Be(2010);
            recommendationMovies[0].Movie.Ids.Should().NotBeNull();
            recommendationMovies[0].Movie.Ids.Trakt.Should().Be(1U);
            recommendationMovies[0].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            recommendationMovies[0].Movie.Ids.Imdb.Should().Be("tt1104001");
            recommendationMovies[0].Movie.Ids.Tmdb.Should().Be(20526U);

            recommendationMovies[1].Should().NotBeNull();
            recommendationMovies[1].Rank.Should().Be(1);
            recommendationMovies[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[1].Type.Should().Be(TraktRecommendationObjectType.Movie);
            recommendationMovies[1].Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            recommendationMovies[1].Movie.Should().NotBeNull();
            recommendationMovies[1].Movie.Title.Should().Be("TRON: Legacy");
            recommendationMovies[1].Movie.Year.Should().Be(2010);
            recommendationMovies[1].Movie.Ids.Should().NotBeNull();
            recommendationMovies[1].Movie.Ids.Trakt.Should().Be(1U);
            recommendationMovies[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            recommendationMovies[1].Movie.Ids.Imdb.Should().Be("tt1104001");
            recommendationMovies[1].Movie.Ids.Tmdb.Should().Be(20526U);
        }

        [Fact]
        public async Task Test_RecommendationMovieArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationMovie>();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            
            IEnumerable<ITraktRecommendationMovie> traktRecommendationMovies = await traktJsonReader.ReadArrayAsync(jsonReader);
            traktRecommendationMovies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendationMovie[] recommendationMovies = traktRecommendationMovies.ToArray();

            recommendationMovies[0].Should().NotBeNull();
            recommendationMovies[0].Rank.Should().Be(1);
            recommendationMovies[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[0].Type.Should().Be(TraktRecommendationObjectType.Movie);
            recommendationMovies[0].Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            recommendationMovies[0].Movie.Should().NotBeNull();
            recommendationMovies[0].Movie.Title.Should().Be("TRON: Legacy");
            recommendationMovies[0].Movie.Year.Should().Be(2010);
            recommendationMovies[0].Movie.Ids.Should().NotBeNull();
            recommendationMovies[0].Movie.Ids.Trakt.Should().Be(1U);
            recommendationMovies[0].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            recommendationMovies[0].Movie.Ids.Imdb.Should().Be("tt1104001");
            recommendationMovies[0].Movie.Ids.Tmdb.Should().Be(20526U);

            recommendationMovies[1].Should().NotBeNull();
            recommendationMovies[1].Rank.Should().BeNull();
            recommendationMovies[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[1].Type.Should().Be(TraktRecommendationObjectType.Movie);
            recommendationMovies[1].Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            recommendationMovies[1].Movie.Should().NotBeNull();
            recommendationMovies[1].Movie.Title.Should().Be("TRON: Legacy");
            recommendationMovies[1].Movie.Year.Should().Be(2010);
            recommendationMovies[1].Movie.Ids.Should().NotBeNull();
            recommendationMovies[1].Movie.Ids.Trakt.Should().Be(1U);
            recommendationMovies[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            recommendationMovies[1].Movie.Ids.Imdb.Should().Be("tt1104001");
            recommendationMovies[1].Movie.Ids.Tmdb.Should().Be(20526U);
        }

        [Fact]
        public async Task Test_RecommendationMovieArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationMovie>();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            
            IEnumerable<ITraktRecommendationMovie> traktRecommendationMovies = await traktJsonReader.ReadArrayAsync(jsonReader);
            traktRecommendationMovies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendationMovie[] recommendationMovies = traktRecommendationMovies.ToArray();

            recommendationMovies[0].Should().NotBeNull();
            recommendationMovies[0].Rank.Should().BeNull();
            recommendationMovies[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[0].Type.Should().Be(TraktRecommendationObjectType.Movie);
            recommendationMovies[0].Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            recommendationMovies[0].Movie.Should().NotBeNull();
            recommendationMovies[0].Movie.Title.Should().Be("TRON: Legacy");
            recommendationMovies[0].Movie.Year.Should().Be(2010);
            recommendationMovies[0].Movie.Ids.Should().NotBeNull();
            recommendationMovies[0].Movie.Ids.Trakt.Should().Be(1U);
            recommendationMovies[0].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            recommendationMovies[0].Movie.Ids.Imdb.Should().Be("tt1104001");
            recommendationMovies[0].Movie.Ids.Tmdb.Should().Be(20526U);

            recommendationMovies[1].Should().NotBeNull();
            recommendationMovies[1].Rank.Should().Be(1);
            recommendationMovies[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[1].Type.Should().Be(TraktRecommendationObjectType.Movie);
            recommendationMovies[1].Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            recommendationMovies[1].Movie.Should().NotBeNull();
            recommendationMovies[1].Movie.Title.Should().Be("TRON: Legacy");
            recommendationMovies[1].Movie.Year.Should().Be(2010);
            recommendationMovies[1].Movie.Ids.Should().NotBeNull();
            recommendationMovies[1].Movie.Ids.Trakt.Should().Be(1U);
            recommendationMovies[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            recommendationMovies[1].Movie.Ids.Imdb.Should().Be("tt1104001");
            recommendationMovies[1].Movie.Ids.Tmdb.Should().Be(20526U);
        }

        [Fact]
        public async Task Test_RecommendationMovieArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationMovie>();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            
            IEnumerable<ITraktRecommendationMovie> traktRecommendationMovies = await traktJsonReader.ReadArrayAsync(jsonReader);
            traktRecommendationMovies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendationMovie[] recommendationMovies = traktRecommendationMovies.ToArray();

            recommendationMovies[0].Should().NotBeNull();
            recommendationMovies[0].Rank.Should().BeNull();
            recommendationMovies[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[0].Type.Should().Be(TraktRecommendationObjectType.Movie);
            recommendationMovies[0].Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            recommendationMovies[0].Movie.Should().NotBeNull();
            recommendationMovies[0].Movie.Title.Should().Be("TRON: Legacy");
            recommendationMovies[0].Movie.Year.Should().Be(2010);
            recommendationMovies[0].Movie.Ids.Should().NotBeNull();
            recommendationMovies[0].Movie.Ids.Trakt.Should().Be(1U);
            recommendationMovies[0].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            recommendationMovies[0].Movie.Ids.Imdb.Should().Be("tt1104001");
            recommendationMovies[0].Movie.Ids.Tmdb.Should().Be(20526U);

            recommendationMovies[1].Should().NotBeNull();
            recommendationMovies[1].Rank.Should().BeNull();
            recommendationMovies[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[1].Type.Should().Be(TraktRecommendationObjectType.Movie);
            recommendationMovies[1].Notes.Should().Be("Daft Punk really knocks it out of the park on the soundtrack.");
            recommendationMovies[1].Movie.Should().NotBeNull();
            recommendationMovies[1].Movie.Title.Should().Be("TRON: Legacy");
            recommendationMovies[1].Movie.Year.Should().Be(2010);
            recommendationMovies[1].Movie.Ids.Should().NotBeNull();
            recommendationMovies[1].Movie.Ids.Trakt.Should().Be(1U);
            recommendationMovies[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            recommendationMovies[1].Movie.Ids.Imdb.Should().Be("tt1104001");
            recommendationMovies[1].Movie.Ids.Tmdb.Should().Be(20526U);
        }

        [Fact]
        public void Test_RecommendationMovieArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationMovie>();
            Func<Task<IEnumerable<ITraktRecommendationMovie>>> traktRecommendationMovies = () => traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktRecommendationMovies.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationMovieArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationMovie>();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            
            IEnumerable<ITraktRecommendationMovie> traktRecommendationMovies = await traktJsonReader.ReadArrayAsync(jsonReader);
            traktRecommendationMovies.Should().BeNull();
        }
    }
}
