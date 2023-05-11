namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonReader")]
    public partial class RecommendationArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecommendationArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktRecommendation>();
            IList<ITraktRecommendation> traktRecommendations = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktRecommendations.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_RecommendationArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktRecommendation>();

            IList<ITraktRecommendation> traktRecommendations = await jsonReader.ReadArrayAsync(JSON_COMPLETE);
            traktRecommendations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendation[] recommendationMovies = traktRecommendations.ToArray();

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
            recommendationMovies[0].Show.Should().BeNull();

            recommendationMovies[1].Should().NotBeNull();
            recommendationMovies[1].Rank.Should().Be(1);
            recommendationMovies[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[1].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationMovies[1].Notes.Should().Be("Atmospheric for days.");
            recommendationMovies[1].Show.Should().NotBeNull();
            recommendationMovies[1].Show.Title.Should().Be("The Walking Dead");
            recommendationMovies[1].Show.Year.Should().Be(2010);
            recommendationMovies[1].Show.Ids.Should().NotBeNull();
            recommendationMovies[1].Show.Ids.Trakt.Should().Be(2U);
            recommendationMovies[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationMovies[1].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationMovies[1].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationMovies[1].Show.Ids.Tmdb.Should().Be(1402U);
            recommendationMovies[1].Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktRecommendation>();

            IList<ITraktRecommendation> traktRecommendations = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);
            traktRecommendations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendation[] recommendationMovies = traktRecommendations.ToArray();

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
            recommendationMovies[0].Show.Should().BeNull();

            recommendationMovies[1].Should().NotBeNull();
            recommendationMovies[1].Rank.Should().BeNull();
            recommendationMovies[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[1].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationMovies[1].Notes.Should().Be("Atmospheric for days.");
            recommendationMovies[1].Show.Should().NotBeNull();
            recommendationMovies[1].Show.Title.Should().Be("The Walking Dead");
            recommendationMovies[1].Show.Year.Should().Be(2010);
            recommendationMovies[1].Show.Ids.Should().NotBeNull();
            recommendationMovies[1].Show.Ids.Trakt.Should().Be(2U);
            recommendationMovies[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationMovies[1].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationMovies[1].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationMovies[1].Show.Ids.Tmdb.Should().Be(1402U);
            recommendationMovies[1].Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktRecommendation>();

            IList<ITraktRecommendation> traktRecommendations = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);
            traktRecommendations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendation[] recommendationMovies = traktRecommendations.ToArray();

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
            recommendationMovies[0].Show.Should().BeNull();

            recommendationMovies[1].Should().NotBeNull();
            recommendationMovies[1].Rank.Should().Be(1);
            recommendationMovies[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[1].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationMovies[1].Notes.Should().Be("Atmospheric for days.");
            recommendationMovies[1].Show.Should().NotBeNull();
            recommendationMovies[1].Show.Title.Should().Be("The Walking Dead");
            recommendationMovies[1].Show.Year.Should().Be(2010);
            recommendationMovies[1].Show.Ids.Should().NotBeNull();
            recommendationMovies[1].Show.Ids.Trakt.Should().Be(2U);
            recommendationMovies[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationMovies[1].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationMovies[1].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationMovies[1].Show.Ids.Tmdb.Should().Be(1402U);
            recommendationMovies[1].Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktRecommendation>();

            IList<ITraktRecommendation> traktRecommendations = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);
            traktRecommendations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendation[] recommendationMovies = traktRecommendations.ToArray();

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
            recommendationMovies[0].Show.Should().BeNull();

            recommendationMovies[1].Should().NotBeNull();
            recommendationMovies[1].Rank.Should().BeNull();
            recommendationMovies[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[1].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationMovies[1].Notes.Should().Be("Atmospheric for days.");
            recommendationMovies[1].Show.Should().NotBeNull();
            recommendationMovies[1].Show.Title.Should().Be("The Walking Dead");
            recommendationMovies[1].Show.Year.Should().Be(2010);
            recommendationMovies[1].Show.Ids.Should().NotBeNull();
            recommendationMovies[1].Show.Ids.Trakt.Should().Be(2U);
            recommendationMovies[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationMovies[1].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationMovies[1].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationMovies[1].Show.Ids.Tmdb.Should().Be(1402U);
            recommendationMovies[1].Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktRecommendation>();

            IList<ITraktRecommendation> traktRecommendations = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);
            traktRecommendations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendation[] recommendationMovies = traktRecommendations.ToArray();

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
            recommendationMovies[0].Show.Should().BeNull();

            recommendationMovies[1].Should().NotBeNull();
            recommendationMovies[1].Rank.Should().Be(1);
            recommendationMovies[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[1].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationMovies[1].Notes.Should().Be("Atmospheric for days.");
            recommendationMovies[1].Show.Should().NotBeNull();
            recommendationMovies[1].Show.Title.Should().Be("The Walking Dead");
            recommendationMovies[1].Show.Year.Should().Be(2010);
            recommendationMovies[1].Show.Ids.Should().NotBeNull();
            recommendationMovies[1].Show.Ids.Trakt.Should().Be(2U);
            recommendationMovies[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationMovies[1].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationMovies[1].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationMovies[1].Show.Ids.Tmdb.Should().Be(1402U);
            recommendationMovies[1].Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktRecommendation>();

            IList<ITraktRecommendation> traktRecommendations = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);
            traktRecommendations.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendation[] recommendationMovies = traktRecommendations.ToArray();

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
            recommendationMovies[0].Show.Should().BeNull();

            recommendationMovies[1].Should().NotBeNull();
            recommendationMovies[1].Rank.Should().BeNull();
            recommendationMovies[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationMovies[1].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationMovies[1].Notes.Should().Be("Atmospheric for days.");
            recommendationMovies[1].Show.Should().NotBeNull();
            recommendationMovies[1].Show.Title.Should().Be("The Walking Dead");
            recommendationMovies[1].Show.Year.Should().Be(2010);
            recommendationMovies[1].Show.Ids.Should().NotBeNull();
            recommendationMovies[1].Show.Ids.Trakt.Should().Be(2U);
            recommendationMovies[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationMovies[1].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationMovies[1].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationMovies[1].Show.Ids.Tmdb.Should().Be(1402U);
            recommendationMovies[1].Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktRecommendation>();
            Func<Task<IList<ITraktRecommendation>>> traktRecommendations = () => jsonReader.ReadArrayAsync(default(string));
            await traktRecommendations.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktRecommendation>();
            IList<ITraktRecommendation> traktRecommendations = await jsonReader.ReadArrayAsync(string.Empty);
            traktRecommendations.Should().BeNull();
        }
    }
}
