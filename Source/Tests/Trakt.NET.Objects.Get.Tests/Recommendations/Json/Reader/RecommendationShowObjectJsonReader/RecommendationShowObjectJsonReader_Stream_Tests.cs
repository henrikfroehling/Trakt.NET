namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Recommendations;
    using TraktNet.Objects.Get.Recommendations.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Recommendations.JsonReader")]
    public partial class RecommendationShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_COMPLETE.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_INCOMPLETE_1.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_INCOMPLETE_2.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_INCOMPLETE_3.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_INCOMPLETE_4.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_INCOMPLETE_5.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().Be(1);
            traktRecommendationShow.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationShow.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendationShow.Notes.Should().Be("Atmospheric for days.");
            traktRecommendationShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_INCOMPLETE_6.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().Be(1);
            traktRecommendationShow.ListedAt.Should().BeNull();
            traktRecommendationShow.Type.Should().BeNull();
            traktRecommendationShow.Notes.Should().BeNull();
            traktRecommendationShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_INCOMPLETE_7.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().BeNull();
            traktRecommendationShow.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationShow.Type.Should().BeNull();
            traktRecommendationShow.Notes.Should().BeNull();
            traktRecommendationShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_INCOMPLETE_8.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().BeNull();
            traktRecommendationShow.ListedAt.Should().BeNull();
            traktRecommendationShow.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendationShow.Notes.Should().BeNull();
            traktRecommendationShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_INCOMPLETE_9.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().BeNull();
            traktRecommendationShow.ListedAt.Should().BeNull();
            traktRecommendationShow.Type.Should().BeNull();
            traktRecommendationShow.Notes.Should().Be("Atmospheric for days.");
            traktRecommendationShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_INCOMPLETE_10.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_NOT_VALID_1.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_NOT_VALID_2.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_NOT_VALID_3.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_NOT_VALID_4.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_NOT_VALID_5.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().Be(1);
            traktRecommendationShow.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRecommendationShow.Type.Should().Be(TraktRecommendationObjectType.Show);
            traktRecommendationShow.Notes.Should().Be("Atmospheric for days.");
            traktRecommendationShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = JSON_NOT_VALID_6.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);

            traktRecommendationShow.Should().NotBeNull();
            traktRecommendationShow.Rank.Should().BeNull();
            traktRecommendationShow.ListedAt.Should().BeNull();
            traktRecommendationShow.Type.Should().BeNull();
            traktRecommendationShow.Notes.Should().BeNull();
            traktRecommendationShow.Show.Should().BeNull();
        }

        [Fact]
        public void Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();
            Func<Task<ITraktRecommendationShow>> traktRecommendationShow = () => jsonReader.ReadObjectAsync(default(Stream));
            traktRecommendationShow.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendationShowObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new RecommendationShowObjectJsonReader();

            using var stream = string.Empty.ToStream();

            ITraktRecommendationShow traktRecommendationShow = await jsonReader.ReadObjectAsync(stream);
            traktRecommendationShow.Should().BeNull();
        }
    }
}
