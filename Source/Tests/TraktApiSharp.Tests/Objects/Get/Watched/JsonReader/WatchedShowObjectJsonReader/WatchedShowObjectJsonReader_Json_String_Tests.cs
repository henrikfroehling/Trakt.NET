namespace TraktApiSharp.Tests.Objects.Get.Watched.JsonReader
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchedShowObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new WatchedShowObjectJsonReader();

            var traktWatchedShow = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktWatchedShow.Should().NotBeNull();
            traktWatchedShow.Plays.Should().Be(1);
            traktWatchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktWatchedShow.Show.Should().NotBeNull();
            traktWatchedShow.Show.Title.Should().Be("Game of Thrones");
            traktWatchedShow.Show.Year.Should().Be(2011);
            traktWatchedShow.Show.Ids.Should().NotBeNull();
            traktWatchedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktWatchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktWatchedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktWatchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktWatchedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktWatchedShow.Show.Ids.TvRage.Should().Be(24493U);

            traktWatchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);
            var seasons = traktWatchedShow.WatchedSeasons.ToArray();

            seasons[0].Should().NotBeNull();
            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodes[1].Should().NotBeNull();
            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            seasons[1].Should().NotBeNull();
            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodes[1].Should().NotBeNull();
            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new WatchedShowObjectJsonReader();

            var traktWatchedShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktWatchedShow.Should().NotBeNull();
            traktWatchedShow.Plays.Should().BeNull();
            traktWatchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktWatchedShow.Show.Should().NotBeNull();
            traktWatchedShow.Show.Title.Should().Be("Game of Thrones");
            traktWatchedShow.Show.Year.Should().Be(2011);
            traktWatchedShow.Show.Ids.Should().NotBeNull();
            traktWatchedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktWatchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktWatchedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktWatchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktWatchedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktWatchedShow.Show.Ids.TvRage.Should().Be(24493U);

            traktWatchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);
            var seasons = traktWatchedShow.WatchedSeasons.ToArray();

            seasons[0].Should().NotBeNull();
            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodes[1].Should().NotBeNull();
            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            seasons[1].Should().NotBeNull();
            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodes[1].Should().NotBeNull();
            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new WatchedShowObjectJsonReader();

            var traktWatchedShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktWatchedShow.Should().NotBeNull();
            traktWatchedShow.Plays.Should().Be(1);
            traktWatchedShow.LastWatchedAt.Should().BeNull();

            traktWatchedShow.Show.Should().NotBeNull();
            traktWatchedShow.Show.Title.Should().Be("Game of Thrones");
            traktWatchedShow.Show.Year.Should().Be(2011);
            traktWatchedShow.Show.Ids.Should().NotBeNull();
            traktWatchedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktWatchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktWatchedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktWatchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktWatchedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktWatchedShow.Show.Ids.TvRage.Should().Be(24493U);

            traktWatchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);
            var seasons = traktWatchedShow.WatchedSeasons.ToArray();

            seasons[0].Should().NotBeNull();
            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodes[1].Should().NotBeNull();
            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            seasons[1].Should().NotBeNull();
            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodes[1].Should().NotBeNull();
            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new WatchedShowObjectJsonReader();

            var traktWatchedShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktWatchedShow.Should().NotBeNull();
            traktWatchedShow.Plays.Should().Be(1);
            traktWatchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktWatchedShow.Show.Should().BeNull();

            traktWatchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);
            var seasons = traktWatchedShow.WatchedSeasons.ToArray();

            seasons[0].Should().NotBeNull();
            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodes[1].Should().NotBeNull();
            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            seasons[1].Should().NotBeNull();
            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodes[1].Should().NotBeNull();
            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new WatchedShowObjectJsonReader();

            var traktWatchedShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktWatchedShow.Should().NotBeNull();
            traktWatchedShow.Plays.Should().Be(1);
            traktWatchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktWatchedShow.Show.Should().NotBeNull();
            traktWatchedShow.Show.Title.Should().Be("Game of Thrones");
            traktWatchedShow.Show.Year.Should().Be(2011);
            traktWatchedShow.Show.Ids.Should().NotBeNull();
            traktWatchedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktWatchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktWatchedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktWatchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktWatchedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktWatchedShow.Show.Ids.TvRage.Should().Be(24493U);

            traktWatchedShow.WatchedSeasons.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new WatchedShowObjectJsonReader();

            var traktWatchedShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktWatchedShow.Should().NotBeNull();
            traktWatchedShow.Plays.Should().Be(1);
            traktWatchedShow.LastWatchedAt.Should().BeNull();
            traktWatchedShow.Show.Should().BeNull();
            traktWatchedShow.WatchedSeasons.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new WatchedShowObjectJsonReader();

            var traktWatchedShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktWatchedShow.Should().NotBeNull();
            traktWatchedShow.Plays.Should().BeNull();
            traktWatchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktWatchedShow.Show.Should().BeNull();
            traktWatchedShow.WatchedSeasons.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new WatchedShowObjectJsonReader();

            var traktWatchedShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktWatchedShow.Should().NotBeNull();
            traktWatchedShow.Plays.Should().BeNull();
            traktWatchedShow.LastWatchedAt.Should().BeNull();

            traktWatchedShow.Show.Should().NotBeNull();
            traktWatchedShow.Show.Title.Should().Be("Game of Thrones");
            traktWatchedShow.Show.Year.Should().Be(2011);
            traktWatchedShow.Show.Ids.Should().NotBeNull();
            traktWatchedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktWatchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktWatchedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktWatchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktWatchedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktWatchedShow.Show.Ids.TvRage.Should().Be(24493U);

            traktWatchedShow.WatchedSeasons.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new WatchedShowObjectJsonReader();

            var traktWatchedShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktWatchedShow.Should().NotBeNull();
            traktWatchedShow.Plays.Should().BeNull();
            traktWatchedShow.LastWatchedAt.Should().BeNull();
            traktWatchedShow.Show.Should().BeNull();

            traktWatchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);
            var seasons = traktWatchedShow.WatchedSeasons.ToArray();

            seasons[0].Should().NotBeNull();
            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodes[1].Should().NotBeNull();
            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            seasons[1].Should().NotBeNull();
            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodes[1].Should().NotBeNull();
            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new WatchedShowObjectJsonReader();

            var traktWatchedShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktWatchedShow.Should().NotBeNull();
            traktWatchedShow.Plays.Should().BeNull();
            traktWatchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktWatchedShow.Show.Should().NotBeNull();
            traktWatchedShow.Show.Title.Should().Be("Game of Thrones");
            traktWatchedShow.Show.Year.Should().Be(2011);
            traktWatchedShow.Show.Ids.Should().NotBeNull();
            traktWatchedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktWatchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktWatchedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktWatchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktWatchedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktWatchedShow.Show.Ids.TvRage.Should().Be(24493U);

            traktWatchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);
            var seasons = traktWatchedShow.WatchedSeasons.ToArray();

            seasons[0].Should().NotBeNull();
            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodes[1].Should().NotBeNull();
            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            seasons[1].Should().NotBeNull();
            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodes[1].Should().NotBeNull();
            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new WatchedShowObjectJsonReader();

            var traktWatchedShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktWatchedShow.Should().NotBeNull();
            traktWatchedShow.Plays.Should().Be(1);
            traktWatchedShow.LastWatchedAt.Should().BeNull();

            traktWatchedShow.Show.Should().NotBeNull();
            traktWatchedShow.Show.Title.Should().Be("Game of Thrones");
            traktWatchedShow.Show.Year.Should().Be(2011);
            traktWatchedShow.Show.Ids.Should().NotBeNull();
            traktWatchedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktWatchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktWatchedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktWatchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktWatchedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktWatchedShow.Show.Ids.TvRage.Should().Be(24493U);

            traktWatchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);
            var seasons = traktWatchedShow.WatchedSeasons.ToArray();

            seasons[0].Should().NotBeNull();
            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodes[1].Should().NotBeNull();
            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            seasons[1].Should().NotBeNull();
            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodes[1].Should().NotBeNull();
            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new WatchedShowObjectJsonReader();

            var traktWatchedShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktWatchedShow.Should().NotBeNull();
            traktWatchedShow.Plays.Should().Be(1);
            traktWatchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktWatchedShow.Show.Should().BeNull();

            traktWatchedShow.WatchedSeasons.Should().NotBeNull().And.HaveCount(2);
            var seasons = traktWatchedShow.WatchedSeasons.ToArray();

            seasons[0].Should().NotBeNull();
            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodes[1].Should().NotBeNull();
            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            seasons[1].Should().NotBeNull();
            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Number.Should().Be(1);
            episodes[0].Plays.Should().Be(1);
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            episodes[1].Should().NotBeNull();
            episodes[1].Number.Should().Be(2);
            episodes[1].Plays.Should().Be(1);
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new WatchedShowObjectJsonReader();

            var traktWatchedShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktWatchedShow.Should().NotBeNull();
            traktWatchedShow.Plays.Should().Be(1);
            traktWatchedShow.LastWatchedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktWatchedShow.Show.Should().NotBeNull();
            traktWatchedShow.Show.Title.Should().Be("Game of Thrones");
            traktWatchedShow.Show.Year.Should().Be(2011);
            traktWatchedShow.Show.Ids.Should().NotBeNull();
            traktWatchedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktWatchedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktWatchedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktWatchedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktWatchedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktWatchedShow.Show.Ids.TvRage.Should().Be(24493U);

            traktWatchedShow.WatchedSeasons.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new WatchedShowObjectJsonReader();

            var traktWatchedShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktWatchedShow.Should().NotBeNull();
            traktWatchedShow.Plays.Should().BeNull();
            traktWatchedShow.LastWatchedAt.Should().BeNull();
            traktWatchedShow.Show.Should().BeNull();
            traktWatchedShow.WatchedSeasons.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new WatchedShowObjectJsonReader();

            var traktWatchedShow = await jsonReader.ReadObjectAsync(default(string));
            traktWatchedShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new WatchedShowObjectJsonReader();

            var traktWatchedShow = await jsonReader.ReadObjectAsync(string.Empty);
            traktWatchedShow.Should().BeNull();
        }
    }
}
