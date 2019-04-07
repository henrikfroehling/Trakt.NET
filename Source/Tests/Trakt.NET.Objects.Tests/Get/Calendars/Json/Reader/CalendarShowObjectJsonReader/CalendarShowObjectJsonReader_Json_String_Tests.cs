namespace TraktNet.Objects.Tests.Get.Calendars.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Calendars.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Calendars.JsonReader")]
    public partial class CalendarShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CalendarShowObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new CalendarShowObjectJsonReader();

            var traktCalendarShow = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktCalendarShow.Should().NotBeNull();
            traktCalendarShow.FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

            traktCalendarShow.Show.Should().NotBeNull();
            traktCalendarShow.Show.Title.Should().Be("Game of Thrones");
            traktCalendarShow.Show.Year.Should().Be(2011);
            traktCalendarShow.Show.Ids.Should().NotBeNull();
            traktCalendarShow.Show.Ids.Trakt.Should().Be(1390U);
            traktCalendarShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCalendarShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktCalendarShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCalendarShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktCalendarShow.Show.Ids.TvRage.Should().Be(24493U);

            traktCalendarShow.Episode.Should().NotBeNull();
            traktCalendarShow.Episode.SeasonNumber.Should().Be(1);
            traktCalendarShow.Episode.Number.Should().Be(1);
            traktCalendarShow.Episode.Title.Should().Be("Winter Is Coming");
            traktCalendarShow.Episode.Ids.Should().NotBeNull();
            traktCalendarShow.Episode.Ids.Trakt.Should().Be(73640U);
            traktCalendarShow.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCalendarShow.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCalendarShow.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCalendarShow.Episode.Ids.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_CalendarShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new CalendarShowObjectJsonReader();

            var traktCalendarShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktCalendarShow.Should().NotBeNull();
            traktCalendarShow.FirstAiredInCalendar.Should().BeNull();

            traktCalendarShow.Show.Should().NotBeNull();
            traktCalendarShow.Show.Title.Should().Be("Game of Thrones");
            traktCalendarShow.Show.Year.Should().Be(2011);
            traktCalendarShow.Show.Ids.Should().NotBeNull();
            traktCalendarShow.Show.Ids.Trakt.Should().Be(1390U);
            traktCalendarShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCalendarShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktCalendarShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCalendarShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktCalendarShow.Show.Ids.TvRage.Should().Be(24493U);

            traktCalendarShow.Episode.Should().NotBeNull();
            traktCalendarShow.Episode.SeasonNumber.Should().Be(1);
            traktCalendarShow.Episode.Number.Should().Be(1);
            traktCalendarShow.Episode.Title.Should().Be("Winter Is Coming");
            traktCalendarShow.Episode.Ids.Should().NotBeNull();
            traktCalendarShow.Episode.Ids.Trakt.Should().Be(73640U);
            traktCalendarShow.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCalendarShow.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCalendarShow.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCalendarShow.Episode.Ids.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_CalendarShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new CalendarShowObjectJsonReader();

            var traktCalendarShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktCalendarShow.Should().NotBeNull();
            traktCalendarShow.FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

            traktCalendarShow.Show.Should().BeNull();

            traktCalendarShow.Episode.Should().NotBeNull();
            traktCalendarShow.Episode.SeasonNumber.Should().Be(1);
            traktCalendarShow.Episode.Number.Should().Be(1);
            traktCalendarShow.Episode.Title.Should().Be("Winter Is Coming");
            traktCalendarShow.Episode.Ids.Should().NotBeNull();
            traktCalendarShow.Episode.Ids.Trakt.Should().Be(73640U);
            traktCalendarShow.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCalendarShow.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCalendarShow.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCalendarShow.Episode.Ids.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_CalendarShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new CalendarShowObjectJsonReader();

            var traktCalendarShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktCalendarShow.Should().NotBeNull();
            traktCalendarShow.FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

            traktCalendarShow.Show.Should().NotBeNull();
            traktCalendarShow.Show.Title.Should().Be("Game of Thrones");
            traktCalendarShow.Show.Year.Should().Be(2011);
            traktCalendarShow.Show.Ids.Should().NotBeNull();
            traktCalendarShow.Show.Ids.Trakt.Should().Be(1390U);
            traktCalendarShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCalendarShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktCalendarShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCalendarShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktCalendarShow.Show.Ids.TvRage.Should().Be(24493U);

            traktCalendarShow.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_CalendarShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new CalendarShowObjectJsonReader();

            var traktCalendarShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktCalendarShow.Should().NotBeNull();
            traktCalendarShow.FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            traktCalendarShow.Show.Should().BeNull();
            traktCalendarShow.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_CalendarShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new CalendarShowObjectJsonReader();

            var traktCalendarShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktCalendarShow.Should().NotBeNull();
            traktCalendarShow.FirstAiredInCalendar.Should().BeNull();

            traktCalendarShow.Show.Should().NotBeNull();
            traktCalendarShow.Show.Title.Should().Be("Game of Thrones");
            traktCalendarShow.Show.Year.Should().Be(2011);
            traktCalendarShow.Show.Ids.Should().NotBeNull();
            traktCalendarShow.Show.Ids.Trakt.Should().Be(1390U);
            traktCalendarShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCalendarShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktCalendarShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCalendarShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktCalendarShow.Show.Ids.TvRage.Should().Be(24493U);

            traktCalendarShow.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_CalendarShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new CalendarShowObjectJsonReader();

            var traktCalendarShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktCalendarShow.Should().NotBeNull();
            traktCalendarShow.FirstAiredInCalendar.Should().BeNull();
            traktCalendarShow.Show.Should().BeNull();

            traktCalendarShow.Episode.Should().NotBeNull();
            traktCalendarShow.Episode.SeasonNumber.Should().Be(1);
            traktCalendarShow.Episode.Number.Should().Be(1);
            traktCalendarShow.Episode.Title.Should().Be("Winter Is Coming");
            traktCalendarShow.Episode.Ids.Should().NotBeNull();
            traktCalendarShow.Episode.Ids.Trakt.Should().Be(73640U);
            traktCalendarShow.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCalendarShow.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCalendarShow.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCalendarShow.Episode.Ids.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_CalendarShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new CalendarShowObjectJsonReader();

            var traktCalendarShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktCalendarShow.Should().NotBeNull();
            traktCalendarShow.FirstAiredInCalendar.Should().BeNull();

            traktCalendarShow.Show.Should().NotBeNull();
            traktCalendarShow.Show.Title.Should().Be("Game of Thrones");
            traktCalendarShow.Show.Year.Should().Be(2011);
            traktCalendarShow.Show.Ids.Should().NotBeNull();
            traktCalendarShow.Show.Ids.Trakt.Should().Be(1390U);
            traktCalendarShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCalendarShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktCalendarShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCalendarShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktCalendarShow.Show.Ids.TvRage.Should().Be(24493U);

            traktCalendarShow.Episode.Should().NotBeNull();
            traktCalendarShow.Episode.SeasonNumber.Should().Be(1);
            traktCalendarShow.Episode.Number.Should().Be(1);
            traktCalendarShow.Episode.Title.Should().Be("Winter Is Coming");
            traktCalendarShow.Episode.Ids.Should().NotBeNull();
            traktCalendarShow.Episode.Ids.Trakt.Should().Be(73640U);
            traktCalendarShow.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCalendarShow.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCalendarShow.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCalendarShow.Episode.Ids.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_CalendarShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new CalendarShowObjectJsonReader();

            var traktCalendarShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktCalendarShow.Should().NotBeNull();
            traktCalendarShow.FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

            traktCalendarShow.Show.Should().BeNull();

            traktCalendarShow.Episode.Should().NotBeNull();
            traktCalendarShow.Episode.SeasonNumber.Should().Be(1);
            traktCalendarShow.Episode.Number.Should().Be(1);
            traktCalendarShow.Episode.Title.Should().Be("Winter Is Coming");
            traktCalendarShow.Episode.Ids.Should().NotBeNull();
            traktCalendarShow.Episode.Ids.Trakt.Should().Be(73640U);
            traktCalendarShow.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCalendarShow.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCalendarShow.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCalendarShow.Episode.Ids.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_CalendarShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new CalendarShowObjectJsonReader();

            var traktCalendarShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktCalendarShow.Should().NotBeNull();
            traktCalendarShow.FirstAiredInCalendar.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

            traktCalendarShow.Show.Should().NotBeNull();
            traktCalendarShow.Show.Title.Should().Be("Game of Thrones");
            traktCalendarShow.Show.Year.Should().Be(2011);
            traktCalendarShow.Show.Ids.Should().NotBeNull();
            traktCalendarShow.Show.Ids.Trakt.Should().Be(1390U);
            traktCalendarShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCalendarShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktCalendarShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCalendarShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktCalendarShow.Show.Ids.TvRage.Should().Be(24493U);

            traktCalendarShow.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_CalendarShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new CalendarShowObjectJsonReader();

            var traktCalendarShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktCalendarShow.Should().NotBeNull();
            traktCalendarShow.FirstAiredInCalendar.Should().BeNull();
            traktCalendarShow.Show.Should().BeNull();
            traktCalendarShow.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_CalendarShowObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new CalendarShowObjectJsonReader();

            var traktCalendarShow = await jsonReader.ReadObjectAsync(default(string));
            traktCalendarShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_CalendarShowObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new CalendarShowObjectJsonReader();

            var traktCalendarShow = await jsonReader.ReadObjectAsync(string.Empty);
            traktCalendarShow.Should().BeNull();
        }
    }
}
