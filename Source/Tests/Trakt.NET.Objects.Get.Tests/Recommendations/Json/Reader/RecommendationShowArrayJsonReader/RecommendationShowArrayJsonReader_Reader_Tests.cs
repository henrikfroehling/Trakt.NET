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
    public partial class RecommendationShowArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecommendationShowArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationShow>();

            using var reader = new StringReader(JSON_EMPTY_ARRAY);
            using var jsonReader = new JsonTextReader(reader);

            IEnumerable<ITraktRecommendationShow> traktRecommendationShows = await traktJsonReader.ReadArrayAsync(jsonReader);
            traktRecommendationShows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_RecommendationShowArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationShow>();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);

            IEnumerable<ITraktRecommendationShow> traktRecommendationShows = await traktJsonReader.ReadArrayAsync(jsonReader);
            traktRecommendationShows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendationShow[] recommendationShows = traktRecommendationShows.ToArray();

            recommendationShows[0].Should().NotBeNull();
            recommendationShows[0].Rank.Should().Be(1);
            recommendationShows[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationShows[0].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationShows[0].Notes.Should().Be("Atmospheric for days.");
            recommendationShows[0].Show.Should().NotBeNull();
            recommendationShows[0].Show.Title.Should().Be("The Walking Dead");
            recommendationShows[0].Show.Year.Should().Be(2010);
            recommendationShows[0].Show.Ids.Should().NotBeNull();
            recommendationShows[0].Show.Ids.Trakt.Should().Be(2U);
            recommendationShows[0].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationShows[0].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationShows[0].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationShows[0].Show.Ids.Tmdb.Should().Be(1402U);

            recommendationShows[1].Should().NotBeNull();
            recommendationShows[1].Rank.Should().Be(1);
            recommendationShows[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationShows[1].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationShows[1].Notes.Should().Be("Atmospheric for days.");
            recommendationShows[1].Show.Should().NotBeNull();
            recommendationShows[1].Show.Title.Should().Be("The Walking Dead");
            recommendationShows[1].Show.Year.Should().Be(2010);
            recommendationShows[1].Show.Ids.Should().NotBeNull();
            recommendationShows[1].Show.Ids.Trakt.Should().Be(2U);
            recommendationShows[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationShows[1].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationShows[1].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationShows[1].Show.Ids.Tmdb.Should().Be(1402U);
        }

        [Fact]
        public async Task Test_RecommendationShowArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationShow>();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);

            IEnumerable<ITraktRecommendationShow> traktRecommendationShows = await traktJsonReader.ReadArrayAsync(jsonReader);
            traktRecommendationShows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendationShow[] recommendationShows = traktRecommendationShows.ToArray();

            recommendationShows[0].Should().NotBeNull();
            recommendationShows[0].Rank.Should().Be(1);
            recommendationShows[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationShows[0].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationShows[0].Notes.Should().Be("Atmospheric for days.");
            recommendationShows[0].Show.Should().NotBeNull();
            recommendationShows[0].Show.Title.Should().Be("The Walking Dead");
            recommendationShows[0].Show.Year.Should().Be(2010);
            recommendationShows[0].Show.Ids.Should().NotBeNull();
            recommendationShows[0].Show.Ids.Trakt.Should().Be(2U);
            recommendationShows[0].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationShows[0].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationShows[0].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationShows[0].Show.Ids.Tmdb.Should().Be(1402U);

            recommendationShows[1].Should().NotBeNull();
            recommendationShows[1].Rank.Should().BeNull();
            recommendationShows[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationShows[1].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationShows[1].Notes.Should().Be("Atmospheric for days.");
            recommendationShows[1].Show.Should().NotBeNull();
            recommendationShows[1].Show.Title.Should().Be("The Walking Dead");
            recommendationShows[1].Show.Year.Should().Be(2010);
            recommendationShows[1].Show.Ids.Should().NotBeNull();
            recommendationShows[1].Show.Ids.Trakt.Should().Be(2U);
            recommendationShows[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationShows[1].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationShows[1].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationShows[1].Show.Ids.Tmdb.Should().Be(1402U);
        }

        [Fact]
        public async Task Test_RecommendationShowArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationShow>();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);

            IEnumerable<ITraktRecommendationShow> traktRecommendationShows = await traktJsonReader.ReadArrayAsync(jsonReader);
            traktRecommendationShows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendationShow[] recommendationShows = traktRecommendationShows.ToArray();

            recommendationShows[0].Should().NotBeNull();
            recommendationShows[0].Rank.Should().BeNull();
            recommendationShows[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationShows[0].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationShows[0].Notes.Should().Be("Atmospheric for days.");
            recommendationShows[0].Show.Should().NotBeNull();
            recommendationShows[0].Show.Title.Should().Be("The Walking Dead");
            recommendationShows[0].Show.Year.Should().Be(2010);
            recommendationShows[0].Show.Ids.Should().NotBeNull();
            recommendationShows[0].Show.Ids.Trakt.Should().Be(2U);
            recommendationShows[0].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationShows[0].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationShows[0].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationShows[0].Show.Ids.Tmdb.Should().Be(1402U);

            recommendationShows[1].Should().NotBeNull();
            recommendationShows[1].Rank.Should().Be(1);
            recommendationShows[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationShows[1].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationShows[1].Notes.Should().Be("Atmospheric for days.");
            recommendationShows[1].Show.Should().NotBeNull();
            recommendationShows[1].Show.Title.Should().Be("The Walking Dead");
            recommendationShows[1].Show.Year.Should().Be(2010);
            recommendationShows[1].Show.Ids.Should().NotBeNull();
            recommendationShows[1].Show.Ids.Trakt.Should().Be(2U);
            recommendationShows[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationShows[1].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationShows[1].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationShows[1].Show.Ids.Tmdb.Should().Be(1402U);
        }

        [Fact]
        public async Task Test_RecommendationShowArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationShow>();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);

            IEnumerable<ITraktRecommendationShow> traktRecommendationShows = await traktJsonReader.ReadArrayAsync(jsonReader);
            traktRecommendationShows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendationShow[] recommendationShows = traktRecommendationShows.ToArray();

            recommendationShows[0].Should().NotBeNull();
            recommendationShows[0].Rank.Should().Be(1);
            recommendationShows[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationShows[0].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationShows[0].Notes.Should().Be("Atmospheric for days.");
            recommendationShows[0].Show.Should().NotBeNull();
            recommendationShows[0].Show.Title.Should().Be("The Walking Dead");
            recommendationShows[0].Show.Year.Should().Be(2010);
            recommendationShows[0].Show.Ids.Should().NotBeNull();
            recommendationShows[0].Show.Ids.Trakt.Should().Be(2U);
            recommendationShows[0].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationShows[0].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationShows[0].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationShows[0].Show.Ids.Tmdb.Should().Be(1402U);

            recommendationShows[1].Should().NotBeNull();
            recommendationShows[1].Rank.Should().BeNull();
            recommendationShows[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationShows[1].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationShows[1].Notes.Should().Be("Atmospheric for days.");
            recommendationShows[1].Show.Should().NotBeNull();
            recommendationShows[1].Show.Title.Should().Be("The Walking Dead");
            recommendationShows[1].Show.Year.Should().Be(2010);
            recommendationShows[1].Show.Ids.Should().NotBeNull();
            recommendationShows[1].Show.Ids.Trakt.Should().Be(2U);
            recommendationShows[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationShows[1].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationShows[1].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationShows[1].Show.Ids.Tmdb.Should().Be(1402U);
        }

        [Fact]
        public async Task Test_RecommendationShowArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationShow>();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);

            IEnumerable<ITraktRecommendationShow> traktRecommendationShows = await traktJsonReader.ReadArrayAsync(jsonReader);
            traktRecommendationShows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendationShow[] recommendationShows = traktRecommendationShows.ToArray();

            recommendationShows[0].Should().NotBeNull();
            recommendationShows[0].Rank.Should().BeNull();
            recommendationShows[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationShows[0].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationShows[0].Notes.Should().Be("Atmospheric for days.");
            recommendationShows[0].Show.Should().NotBeNull();
            recommendationShows[0].Show.Title.Should().Be("The Walking Dead");
            recommendationShows[0].Show.Year.Should().Be(2010);
            recommendationShows[0].Show.Ids.Should().NotBeNull();
            recommendationShows[0].Show.Ids.Trakt.Should().Be(2U);
            recommendationShows[0].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationShows[0].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationShows[0].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationShows[0].Show.Ids.Tmdb.Should().Be(1402U);

            recommendationShows[1].Should().NotBeNull();
            recommendationShows[1].Rank.Should().Be(1);
            recommendationShows[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationShows[1].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationShows[1].Notes.Should().Be("Atmospheric for days.");
            recommendationShows[1].Show.Should().NotBeNull();
            recommendationShows[1].Show.Title.Should().Be("The Walking Dead");
            recommendationShows[1].Show.Year.Should().Be(2010);
            recommendationShows[1].Show.Ids.Should().NotBeNull();
            recommendationShows[1].Show.Ids.Trakt.Should().Be(2U);
            recommendationShows[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationShows[1].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationShows[1].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationShows[1].Show.Ids.Tmdb.Should().Be(1402U);
        }

        [Fact]
        public async Task Test_RecommendationShowArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationShow>();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);

            IEnumerable<ITraktRecommendationShow> traktRecommendationShows = await traktJsonReader.ReadArrayAsync(jsonReader);
            traktRecommendationShows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            ITraktRecommendationShow[] recommendationShows = traktRecommendationShows.ToArray();

            recommendationShows[0].Should().NotBeNull();
            recommendationShows[0].Rank.Should().BeNull();
            recommendationShows[0].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationShows[0].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationShows[0].Notes.Should().Be("Atmospheric for days.");
            recommendationShows[0].Show.Should().NotBeNull();
            recommendationShows[0].Show.Title.Should().Be("The Walking Dead");
            recommendationShows[0].Show.Year.Should().Be(2010);
            recommendationShows[0].Show.Ids.Should().NotBeNull();
            recommendationShows[0].Show.Ids.Trakt.Should().Be(2U);
            recommendationShows[0].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationShows[0].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationShows[0].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationShows[0].Show.Ids.Tmdb.Should().Be(1402U);

            recommendationShows[1].Should().NotBeNull();
            recommendationShows[1].Rank.Should().BeNull();
            recommendationShows[1].ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            recommendationShows[1].Type.Should().Be(TraktRecommendationObjectType.Show);
            recommendationShows[1].Notes.Should().Be("Atmospheric for days.");
            recommendationShows[1].Show.Should().NotBeNull();
            recommendationShows[1].Show.Title.Should().Be("The Walking Dead");
            recommendationShows[1].Show.Year.Should().Be(2010);
            recommendationShows[1].Show.Ids.Should().NotBeNull();
            recommendationShows[1].Show.Ids.Trakt.Should().Be(2U);
            recommendationShows[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            recommendationShows[1].Show.Ids.Tvdb.Should().Be(153021U);
            recommendationShows[1].Show.Ids.Imdb.Should().Be("tt1520211");
            recommendationShows[1].Show.Ids.Tmdb.Should().Be(1402U);
        }

        [Fact]
        public void Test_RecommendationShowArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationShow>();
            Func<Task<IEnumerable<ITraktRecommendationShow>>> traktRecommendationShows = () => traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktRecommendationShows.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationShowArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktRecommendationShow>();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            IEnumerable<ITraktRecommendationShow> traktRecommendationShows = await traktJsonReader.ReadArrayAsync(jsonReader);
            traktRecommendationShows.Should().BeNull();
        }
    }
}
